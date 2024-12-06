using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipProvider : MonoBehaviour, ITipHandler
{
    public string textTip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public virtual string GetTip(GameObject instigator)
    {
        return textTip;
    }
}
