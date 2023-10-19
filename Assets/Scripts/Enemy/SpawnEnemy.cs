using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    //Game objwct for the current enemy wace spawning
    public GameObject Wave;

    private void OnTriggerEnter(Collider other)
    {
        //When the player hits a specified trigger, the corresponding wave will activate
        if (other.tag == "Player")
        Wave.SetActive(true);
    }
}
