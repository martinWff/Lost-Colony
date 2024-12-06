using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable;
        if (collision.gameObject.TryGetComponent<IDamageable>(out damageable))
        {
            damageable.TakeDamage(damage);
        }

        if (!collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
        }

    }
}
