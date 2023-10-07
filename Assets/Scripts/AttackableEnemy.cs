using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))]
public class AttackableEnemy : MonoBehaviour
{
    private NavMeshAgent iceMonster;
    private Rigidbody imrb;
    private Vector3 iceMonsterDestination;

    bool isRagdolling = false;

    private void Awake()
    {
        iceMonster = GetComponent<NavMeshAgent>();
        imrb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isRagdolling)
        {
            if (imrb.velocity.magnitude < 0.1f)
            {
                NavMeshHit navMeshHit;
                if (NavMesh.SamplePosition(imrb.position, out navMeshHit, 0.5f, NavMesh.AllAreas))
                {
                    imrb.isKinematic = true;

                    iceMonster.Warp(navMeshHit.position);
                    iceMonster.updatePosition = true;
                    iceMonster.SetDestination(iceMonsterDestination);

                    isRagdolling = false;
                }
            }
        }
    }

    public void OnPlayerAttack (Vector3 hitDirection)
    {
        if (isRagdolling == false)
        {
            iceMonsterDestination = iceMonster.destination;
            iceMonster.ResetPath();
            iceMonster.updatePosition = false;

            imrb.isKinematic = false;

            imrb.velocity = hitDirection.normalized * 20 + Vector3.up * 5;

            isRagdolling = true;
        }
    }

}
