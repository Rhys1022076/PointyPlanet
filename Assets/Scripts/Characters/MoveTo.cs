using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public string movingParameterName;

    public Animator animator;
    public NavMeshAgent agent;
    public Transform position;

    public void BeginMove()
    {
        agent.SetDestination(position.position);
        animator.SetBool(movingParameterName, true);
    }

    private void Update()
    {
        if (agent.isStopped && animator.GetBool(movingParameterName))
        {
            animator.SetBool(movingParameterName, false);
        }
    }

}
