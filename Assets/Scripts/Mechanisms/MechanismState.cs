using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MechanismState : MonoBehaviour
{
    public abstract void Init();
    public abstract void OnRestart();
}
