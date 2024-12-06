using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealth;
    [SerializeField] float health;

    public UnityEvent<float> onDamaged;
    
    public UnityEvent<float> onDied;

    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        onDamaged.Invoke(dmg);

        if (health < 0)
        {
            health = 0;
        }
        if (health == 0)
        {
            onDied.Invoke(dmg);
        }

    }

    public void IncreaseHealth(float value)
    {
        value = Mathf.Abs(value);

        health += value;
        health = Mathf.Clamp(health, 0, maxHealth);
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float value)
    {
        health = Mathf.Clamp(value,0,maxHealth);
    }

}
