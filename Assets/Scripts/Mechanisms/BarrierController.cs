using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Open()
    {
        gameObject.SetActive(false);
    }
}
