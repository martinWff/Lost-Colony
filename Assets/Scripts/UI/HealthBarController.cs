using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField]Health health;
    [SerializeField] Image healthBar;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar != null && health != null)
        {
            healthBar.fillAmount = (health.GetHealth() / health.maxHealth);
        }
    }
}
