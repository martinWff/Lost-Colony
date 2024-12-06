using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Waypoint : MonoBehaviour
{
    public Waypoint nextWaypoint;

    public UnityEvent onReached;

    public bool haltTrainProgress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1);
        if (nextWaypoint != null) {
            Gizmos.DrawLine(transform.position, nextWaypoint.transform.position);
        }
    }
}
