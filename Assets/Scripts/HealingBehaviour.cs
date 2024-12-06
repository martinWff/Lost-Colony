using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBehaviour : MonoBehaviour, IInteractable, ITipHandler
{
    public float charges = 100;
    public float extractValue = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Interact(GameObject instigator)
    {
        if (charges > 0) {
            Health health = instigator.GetComponent<Health>();
            if (health != null)
            {
                float v = Mathf.Min(extractValue, charges);
                charges -= v;

                health.SetHealth(health.GetHealth() + v);
            }
        }
    }

    public string GetTip(GameObject instigator)
    {
        return string.Format("Press E to heal {0} health points,<color=red> {1} charges remaining!</color>", extractValue, charges);
    }
}
