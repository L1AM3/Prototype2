using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveToDestination : MonoBehaviour
{
    //Point placed on player for enemies to follow
    public Transform Destination;
    //Navmesh agent for the enemy
    private NavMeshAgent iceMonster;

    private void Awake()
    {
        //Gets the navmesh agent component
        iceMonster = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Sets agent destination to follow the player
        iceMonster.destination = Destination.position;
    }
}
