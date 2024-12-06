using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFinder : MonoBehaviour
{
    private Waypoint waypointReached;
    [SerializeField]LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        Ray r = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(r,out hit, 1, layerMask, QueryTriggerInteraction.Collide))
        {

            Waypoint wp;
            if (hit.transform.TryGetComponent<Waypoint>(out wp))
            {
                waypointReached = wp;
            }
        }
    }

    public Waypoint GetWaypoint()
    {
        return waypointReached;
    }

    public bool HasReachedWaypoint()
    {
        return waypointReached != null;
    }
}
