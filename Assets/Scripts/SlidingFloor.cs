using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingFloor : MonoBehaviour
{
    public Waypoint initial;
    private float distance;

    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (initial != null)
        {
            transform.position = initial.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (initial != null && initial.nextWaypoint != null)
        {
            transform.position = Vector3.Lerp(initial.transform.position, initial.nextWaypoint.transform.position, distance);
            if (transform.position == initial.nextWaypoint.transform.position)
            {
                initial = initial.nextWaypoint;
                distance = 0;
            }
            else
            {
                distance += Time.deltaTime * speed;
            }
        }
    }
}
