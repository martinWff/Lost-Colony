using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMechanismState : MechanismState
{
    public Health health;

    private float _health = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Init()
    {
        _health = health.GetHealth();   
    }

    public override void OnRestart()
    {
        health.SetHealth(_health);
    }

}
