using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IDamageable
{
    public Health health;
    public bool invulnerability;
    [SerializeField] Transform interactCaster;

    [SerializeField] float interactDistance;

    public string currentTip { get; private set; }

    public Weapon weapon;

    [SerializeField] int gameOverScene;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        IInteractable interactable = null;
        ITipHandler tipHandler = null;

        Ray ray = new Ray(interactCaster.position, interactCaster.forward);
        RaycastHit hit;
        if (Physics.Raycast(interactCaster.position, interactCaster.forward, out hit, interactDistance))
        {
            interactable = hit.transform.GetComponent<IInteractable>();
            tipHandler = hit.transform.GetComponent<ITipHandler>();
         
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactable != null)
            {
                interactable.Interact(gameObject);
            }
        }

        if (tipHandler != null)
        {
            currentTip = tipHandler.GetTip(gameObject); 
        } else
        {
            currentTip = string.Empty;
        }


        if (Input.GetMouseButton(0))
        {
            if (weapon != null)
            {
                weapon.Shoot();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (weapon != null)
            {
                weapon.Reload();
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            invulnerability = !invulnerability;
            currentTip = "Invulnerability cheat set to " + invulnerability;
        }
    }

    public void TakeDamage(float dmg)
    {
        if (!invulnerability)
        {
            health.TakeDamage(dmg);
        }
    }

    public void Kill()
    {
        Invoke("OnDied", 1);
    }

    public void OnDied()
    {
        SceneManager.LoadScene(gameOverScene);

    }
}
