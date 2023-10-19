using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Wave;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        Wave.SetActive(true);
    }
}
