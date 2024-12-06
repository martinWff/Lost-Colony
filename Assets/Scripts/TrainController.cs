using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public Waypoint startWaypoint;
    public Waypoint currentWaypoint;

    public float speed = 0;

    private CharacterController controller;

    [SerializeField] Transform waypointReader;
    [SerializeField] WaypointFinder finder;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (currentWaypoint != null && !currentWaypoint.haltTrainProgress)
        {
            Waypoint nextWaypoint = currentWaypoint.nextWaypoint;
            if (nextWaypoint == null)
                return;
            //  transform.position = Vector3.MoveTowards(currentWaypoint.transform.position, nextWaypoint.transform.position,distance);
            //distance += Time.deltaTime;


            Vector3 currentPosition = waypointReader.position;


            Vector3 direction = nextWaypoint.transform.position - currentPosition;

            controller.SimpleMove(direction.normalized * speed);

            Waypoint wp = finder.GetWaypoint();
            if (currentWaypoint != wp && wp != null)
            {
                nextWaypoint.onReached.Invoke();
                currentWaypoint = wp;
            }


        }

    }


    public void MoveToNextWaypoint()
    {
        
    }
}
