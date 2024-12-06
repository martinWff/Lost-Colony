using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    public Transform barrel;

    public GameObject bullet;

    public bool isReloading { get; protected set; }

    public float reloadingDuration;
    private float currentReloadingDuration;

    public int magazineSize;
    [SerializeField]private int ammo = 0;

    public int barrelCount = 1;
    public float shootingCooldown;
    private float currentShootingCooldown;

    public ObjectPool<GameObject> bullets;

    private List<GameObject> spawnedBullets = new List<GameObject>();
    private Dictionary<GameObject,float> timers = new Dictionary<GameObject, float>();

    public int GetAmmo()
    {
        return ammo;
    }



    // Start is called before the first frame update
    void Start()
    {
        ammo = magazineSize;
        bullets = new ObjectPool<GameObject>(CreateBullet, GetBullet, ReturnPool, DestroyBullet, true, magazineSize,magazineSize+10);
    }

    // Update is called once per frame
    void Update()
    {
        ReleaseBullets();

        if (isReloading)
        {
            if (currentReloadingDuration > 0)
            {
                currentReloadingDuration -= Time.deltaTime;
            } else
            {

               // ReleaseAllBullets();

                ammo = magazineSize;
                isReloading = false;
            }

        }

        if (currentShootingCooldown > 0)
        {
            currentShootingCooldown -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (ammo >= barrelCount)
        {
            if (currentShootingCooldown <= 0)
            {
                for (int i = 0; i < barrelCount; i++)
                {
                    GameObject spawned = bullets.Get();
                    /*if (spawned != null)
                    {
                        spawned.transform.position = barrel.position;
                        spawned.transform.rotation = barrel.rotation;
                        ammo--;

                        Destroy(spawned, 10);
                    }*/
                }
                currentShootingCooldown = shootingCooldown;

            }
        }

        
    }

    public void Reload()
    {
        if (!isReloading)
        {
            currentReloadingDuration = reloadingDuration;
            isReloading = true;
        }
    }

    private void ReleaseAllBullets()
    {
        for (int i = spawnedBullets.Count - 1; i >= 0; i--)
        {
            bullets.Release(spawnedBullets[i]);

        }
    }

    private void ReleaseBullets()
    {
        for (int i = spawnedBullets.Count - 1; i >= 0; i--)
        {
            GameObject g = spawnedBullets[i];
            bool canBeReleased = false;

            float currentTimer;
            if (!g.activeSelf)
            {
                canBeReleased = true;
            }

            if (timers.TryGetValue(g, out currentTimer))
            {
                if (currentTimer <= 0)
                {
                    canBeReleased = true;
                }
                timers[g] = currentTimer -= Time.deltaTime;
            }

            if (canBeReleased)
            {
                bullets.Release(g);

            }


        }
    }

    private GameObject CreateBullet()
    {
        return Instantiate(bullet);
    }

    private void GetBullet(GameObject b)
    {
        if (b != null)
        {
            b.transform.position = barrel.position;
            b.transform.rotation = barrel.rotation;
            b.GetComponent<Rigidbody>().velocity = Vector3.zero;
            b.SetActive(true);
            ammo--;

            spawnedBullets.Add(b);
            timers.Add(b, 1f);
        }
    }


    public float GetCurrentReloadingDuration()
    {
        return currentReloadingDuration;
    }
    private void DestroyBullet(GameObject b)
    {
        Destroy(b);
    }

    private void ReturnPool(GameObject b)
    {
        b.SetActive(false);
        spawnedBullets.Remove(b);
        timers.Remove(b);
    }
}
