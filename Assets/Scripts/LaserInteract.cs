using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserInteract : MonoBehaviour
{
    public bool IsActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!IsActive)
        {
            return;
        }

        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().EnemyHealthDecrease();
        }
    }
}
