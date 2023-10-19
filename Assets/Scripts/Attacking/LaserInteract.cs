using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserInteract : MonoBehaviour
{
    //bool that shows whether laser is active
    public bool IsActive = false;

    private void OnTriggerEnter(Collider other)
    {
        //If the laser is active, the laser will do nothing
        if (!IsActive)
        {
            return;
        }

        //If the laser is active and hits an enemy it will do damage
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().EnemyHealthDecrease();
        }
    }
}
