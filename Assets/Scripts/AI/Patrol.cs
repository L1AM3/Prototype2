using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] patrolPoints;

    private NavMeshAgent agent;

    private int currentIndex = 0;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.SetDestination(patrolPoints[0].position);
    }

    private void Update()
    {
        if (agent.pathPending == false && agent.remainingDistance < 0.5f)
        {
            currentIndex = (currentIndex + 1) % patrolPoints.Length;

            agent.SetDestination(patrolPoints[currentIndex].position);
        }
    }
}
