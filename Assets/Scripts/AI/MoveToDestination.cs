using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveToDestination : MonoBehaviour
{
    public Transform Destination;
    NavMeshAgent iceMonster;

    private void Awake()
    {
        iceMonster = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        iceMonster.destination = Destination.position;
    }
}
