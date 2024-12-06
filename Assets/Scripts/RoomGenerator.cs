using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public List<GameObject> potentialRooms;

    public GameObject starterRoom;

    public GameObject emptyRoom;

    public GameObject bossRoom;

    public int roomNum;

    private int spawnedRoomCount = 0;


    public Transform generationStartingPoint;

    public int separatingRoomsCount = 1;

    [HideInInspector]public List<GameObject> spawnedRooms = new List<GameObject>();

    public GameObject train;

    public bool generateRoomsOnStart = true;
    public bool generateTrainOnStart = true;

    // Start is called before the first frame update
    void Start()
    {
        if (generateRoomsOnStart)
        {
            Generate();
        }
        if (generateTrainOnStart)
        {
            GenerateTrain();
        }
    }

    public void Generate()
    {
        CreateRoom(starterRoom);

        for (int i = 0; i < roomNum; i++)
        {

            CreateSeparationRooms();

            int index = Random.Range(0, potentialRooms.Count);
            CreateRoom(potentialRooms[index]);

        }

        CreateSeparationRooms();

        CreateRoom(bossRoom);

        CreateConnections();
    }


    void CreateSeparationRooms()
    {
        for (int i = 0; i < separatingRoomsCount;i++) {
            CreateRoom(emptyRoom);
        }
    }

    void CreateRoom(GameObject obj)
    {
        GameObject room = Instantiate(obj, generationStartingPoint);

        int z = 20 * spawnedRoomCount;
        room.transform.position = generationStartingPoint.position + new Vector3(0, 0, z);


        spawnedRoomCount++;

        spawnedRooms.Add(room);
    }


    void CreateConnections()
    {
        for (int i = 1;i<spawnedRooms.Count;i++)
        {
            Waypoint previousRoomWaypoint = FindRoomExitWaypoint(spawnedRooms[i-1]);
            Waypoint currentRoomWaypoint = FindRoomEntryWaypoint(spawnedRooms[i]);

            previousRoomWaypoint.nextWaypoint = currentRoomWaypoint;
            

            
        }
    }

    public void Clear()
    {
        foreach (GameObject obj in spawnedRooms)
        {
            Destroy(obj);
        }

        spawnedRooms.Clear();
    }

    public GameObject GenerateTrain()
    {
        if (spawnedRooms.Count == 0)
            return null;
        GameObject spawn = spawnedRooms[0];


        GameObject sTrain = null;


        Waypoint waypoint = FindRoomEntryWaypoint(spawn);
        if (waypoint != null)
        {
            sTrain = Instantiate(train, waypoint.transform.position,Quaternion.identity);

            TrainController controller;
            if (sTrain.TryGetComponent<TrainController>(out controller))
            {
                controller.currentWaypoint = FindRoomEntryWaypoint(spawn);
            }
        }

        



        return sTrain;
    }


    public Waypoint FindRoomEntryWaypoint(GameObject room)
    {
        Room r;
        if (room.TryGetComponent<Room>(out r))
        {
            return r.entryWaypoint;
        }
        else
        {
            return FindWaypointWithName(room, "Entry");
        }
    }

    public Waypoint FindRoomExitWaypoint(GameObject room)
    {
        Room r;
        if (room.TryGetComponent<Room>(out r))
        {
            return r.exitWaypoint;
        }
        else
        {
            return FindWaypointWithName(room,"Exit");
        }
    }

    private Waypoint FindWaypointWithName(GameObject room,string waypointName)
    {
        Transform tr = room.transform.Find(waypointName);
        if (tr == null)
            return null;

        return tr.GetComponent<Waypoint>();
    }

}
