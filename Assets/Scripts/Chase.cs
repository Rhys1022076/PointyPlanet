using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Chase : MonoBehaviour
{

    public Transform target; //allows target to be set in Inspector
    private NavMeshAgent agent; 


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        ChaseTarget();
    }

    public void ChaseTarget()
    {
        // Set the agent to go to the currently selected target;
        agent.destination = target.position;
    }

    public void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            ChaseTarget();
    }
}

