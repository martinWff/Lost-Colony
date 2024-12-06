using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mechanism : MonoBehaviour
{
    public List<MechanismCondition> conditions = new List<MechanismCondition>();

    public UnityEvent onRestart;

    public UnityEvent onSuccess;

    public List<MechanismState> states = new List<MechanismState>();


    [SerializeField] bool stopAfterSuccess;
    [SerializeField] bool destroyOnSuccess;

    [SerializeField] bool runMechanismOnStart = true;

    public Waypoint unlockWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        if (runMechanismOnStart)
        {
            RunMechanism();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0;i<conditions.Count;i++)
        {
            if (!conditions[i].Test())
            {
                return;
            }
        }


        Complete();
        if (stopAfterSuccess)
        {
            enabled = false;
        }
        if (destroyOnSuccess)
        {
            Destroy(gameObject);
        }
    }

    public void RunMechanism()
    {
        for (int i = 0; i < states.Count; i++)
        {
            states[i].Init();
        }
    }

    public void Restart()
    {
        for (int i = 0;i<states.Count;i++)
        {
            states[i].OnRestart();
        }

        onRestart.Invoke();
    }

    [ContextMenu("Complete Mechanism")]

    public void Complete()
    {
        onSuccess.Invoke();

        if (unlockWaypoint != null)
        {
            unlockWaypoint.haltTrainProgress = false;
        }
    }


    [ContextMenu("Restart Mechanism")]
    private void DoRestart()
    {
        Restart();
    }

    [ContextMenu("Run Mechanism")]
    private void DoRun()
    {
        RunMechanism();
    }

}
