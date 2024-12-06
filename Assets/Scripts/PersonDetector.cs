using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PersonDetector : MonoBehaviour
{
    public bool detectorOn;

    private GameObject targetFound;

    public UnityEvent<GameObject> onTargetFound;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (detectorOn)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                targetFound = other.gameObject;
                if (onTargetFound != null)
                {
                    onTargetFound.Invoke(targetFound);
                }
            }
        }
    }
}
