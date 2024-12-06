using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMechanismState : MechanismState
{
    bool state;
    // Start is called before the first frame update
    public override void Init()
    {
        state = gameObject.activeSelf;
    }

    public override void OnRestart()
    {
        gameObject.SetActive(state);
    }
}
