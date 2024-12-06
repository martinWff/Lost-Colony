using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingBehaviour : MonoBehaviour
{
    public int blinkChance = 20;
    public float blinkPeriod = 1.2f;
    public float blinkWaitingPeriod = 0.8f;
    private float currentCooldown = 0;
    private float currentBlinkTimer = 0;
    private bool isBlinking;

    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = blinkWaitingPeriod;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isBlinking)
        {
            if (currentCooldown <= 0)
            {
                currentCooldown = blinkWaitingPeriod;
                int v = Random.Range(1, 21);
                if (blinkChance >= v)
                {
                    isBlinking = true;
                    currentBlinkTimer = blinkPeriod;
                }


            }
            else
            {
                currentCooldown -= Time.deltaTime;
            }

        } else
        {
            if (currentBlinkTimer <= 0)
            {
                isBlinking = false;
            } else
            {
                currentBlinkTimer -= Time.deltaTime;
            }
        }
    }

    public bool IsBlinking()
    {
        return isBlinking;
    }
}
