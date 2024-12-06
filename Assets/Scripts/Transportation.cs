using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transportation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other.transform.parent == transform)
        {
            other.gameObject.transform.SetParent(transform.root);
        }

    }
}
