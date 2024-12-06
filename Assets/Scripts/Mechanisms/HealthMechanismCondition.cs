using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMechanismCondition : MechanismCondition
{
    public Health health;

    public float targetHealth;

    public int compareType;

    public override bool Test()
    {
 
        return health.GetHealth().CompareTo(targetHealth) == compareType;
    }

}
