 using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;


    public class Patrol : MonoBehaviour 
    {
        public Transform[] points;
        public int destPoint = 0;
        private NavMeshAgent agent;

        void Awake () 
        {
            agent = GetComponent<NavMeshAgent>();

            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = false;
            
            GotoNextPoint();
        }


        public void GotoNextPoint() 
        {
            
            // Returns if no points have been set up
            if (points.Length == 0)
                return;
            agent.stoppingDistance = 0;
            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }


        void Update () 
        {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }

        public void StopAgent()
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }
