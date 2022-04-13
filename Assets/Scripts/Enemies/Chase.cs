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
        if(gameObject.tag == "Rabbit")
        {
            agent.stoppingDistance = 10f;
        }

        // Set the agent to go to the currently selected target;
        agent.destination = target.position;
    }

    public void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance > 5f)
            ChaseTarget();

        //dist = Vector3.Distance(transform.position, target.transform.position);

        //if(isChasing && dist != 10)
        //{
        //    Debug.Log(dist);
        //    dist = 10;
        //    transform.position = (transform.position - target.position).normalized * dist + target.position;
        //}

        //Vector3 avoidance = target.position;
        //transform.RotateAround(avoidance, Vector3.up, 20 * Time.deltaTime);
    }
}

