using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class TurretController : MonoBehaviour, IDamageable
{
    // Start is called before the first frame update

    public float cooldown;

    private float currentCooldown;

    public bool isEnabled = true;

    public Transform target;

    public float detectionRange;

    [SerializeField] Transform barrel;

    [SerializeField] GameObject bullet;

    private Health health;

    public Weapon[] weapons;


    private bool shuttingDownAnim;
    private float initialShuttingDownValue;
    private float shuttingDownTimer = 0;

    private float targetShutdownXValue;


    void Start()
    {
        currentCooldown = cooldown;
        health = GetComponent<Health>();
        weapons = GetComponentsInChildren<Weapon>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!shuttingDownAnim) {
            if (isEnabled)
            {
                if (target != null)
                {
                    float distance = Vector3.Distance(target.position, transform.position);
                    if (distance < detectionRange)
                    {

                        //takes the direction of the target
                        Vector3 direction = target.position - transform.position;

                        Vector3 barrelDirection = target.position - barrel.transform.position;

                        //creates a rotation pointing at the target
                        Quaternion rotatedQuaternion = Quaternion.LookRotation(direction, transform.up);

                        Quaternion barrelRotatedQuaternion = Quaternion.LookRotation(barrelDirection, transform.up);

                        //gets the euler angles of the created rotation
                        Vector3 rotatedEulerAngles = rotatedQuaternion.eulerAngles;


                        //gets the current body rotation
                        Vector3 bodyCurrentRotation = transform.rotation.eulerAngles;

                        //gets the current barrel rotation
                        Vector3 barrelCurrentRotation = barrel.localRotation.eulerAngles;

                        bodyCurrentRotation.y = rotatedEulerAngles.y;

                        barrelCurrentRotation.x = barrelRotatedQuaternion.eulerAngles.x;

                        transform.rotation = Quaternion.Euler(bodyCurrentRotation);
                        // barrel.rotation = Quaternion.Euler(new Vector3(rotatedEulerAngles.x, barrelCurrentRotation.y,barrelCurrentRotation.z));

                        barrel.localRotation = Quaternion.Euler(barrelCurrentRotation);

                        //barrel.localRotation = Quaternion.Euler(barrelCurrentRotation);
                        //  transform.LookAt(target.position, Vector3.up);

                        for (int i = 0; i < weapons.Length; i++)
                        {
                            Weapon weapon = weapons[i];
                            int ammo = weapon.GetAmmo();
                            if (ammo >= weapon.barrelCount)
                            {
                                weapon.Shoot();
                            }
                            else
                            {
                                weapon.Reload();

                            }
                        }

                    }
                }
            }
        } else {
            Vector3 current = barrel.localEulerAngles;
            current.x = Mathf.LerpAngle(initialShuttingDownValue, targetShutdownXValue, shuttingDownTimer);
            barrel.localEulerAngles = current;
            shuttingDownTimer += Time.deltaTime * 10;
            if (current.x == targetShutdownXValue)
            {
                shuttingDownTimer = 0;
                shuttingDownAnim = false;
            }
        }


    }

    public void TakeDamage(float dmg)
    {
        health.TakeDamage(dmg);
    }
    
    [ContextMenu("Shutdown")]
    public void Shutdown()
    {
        Vector3 current = barrel.localEulerAngles;
        initialShuttingDownValue = current.x;
        //   barrel.localEulerAngles = new Vector3(31.16f,current.y,current.z);
        targetShutdownXValue = 31.16f;
        isEnabled = false;
        shuttingDownAnim = true;
    }

    [ContextMenu("Turn On")]

    public void TurnOn()
    {
        Vector3 current = barrel.localEulerAngles;
        initialShuttingDownValue = current.x;
        targetShutdownXValue = 0f;
        //barrel.localEulerAngles = new Vector3(0, current.y, current.z);
        isEnabled = true;
        shuttingDownAnim = true;
    }
}
