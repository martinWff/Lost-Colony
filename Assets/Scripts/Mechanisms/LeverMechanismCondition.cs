using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMechanismCondition : MechanismCondition, IInteractable, ITipHandler
{
    public bool isOn;

    public string offTip;
    public string onTip;

    public override bool Test()
    {
        return isOn;
    }

    public void Interact(GameObject instigator)
    {
        isOn = true;
    }

    public virtual string GetTip(GameObject instigator)
    {
        if (isOn)
        {
            return onTip;
        } else
        {
            return offTip;
        }
    }
}
