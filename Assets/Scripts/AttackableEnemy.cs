using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))]
public class AttackableEnemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;
    private Vector3 iceMonsterDestination;

    bool isRagdolling = false;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        

        if (isRagdolling)
        {
            Debug.Log("DFSDFSDF");

            Debug.DrawRay(transform.position, rb.velocity, Color.cyan);

            if (rb.velocity.magnitude < 0.1f)
            {
                NavMeshHit navMeshHit;
                if (NavMesh.SamplePosition(rb.position, out navMeshHit, 0.5f, NavMesh.AllAreas))
                {
                    rb.isKinematic = true;

                    navMeshAgent.Warp(navMeshHit.position);
                    navMeshAgent.updatePosition = true;
                    navMeshAgent.SetDestination(iceMonsterDestination);

                    isRagdolling = false;
                }
            }
        }
    }

    public void OnPlayerAttack (Vector3 hitDirection)
    {
        if (isRagdolling == false)
        {
            //iceMonsterDestination = iceMonster.destination;
            navMeshAgent.ResetPath();
            navMeshAgent.updatePosition = false;

            rb.isKinematic = false;

            rb.velocity = hitDirection.normalized * 20 + Vector3.up * 500;

            isRagdolling = true;
        }
    }

}
