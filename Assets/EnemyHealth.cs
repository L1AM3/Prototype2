using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int EnemyHealthCount = 3;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(EnemyHealthCount);
        if (other.tag == "Laser")
        {
            EnemyHealthCount--;
            Debug.Log(EnemyHealthCount);
            EnemyDeath();
        }

    }



    public void EnemyDeath()
    {
        if (EnemyHealthCount > 0)
        {
            gameObject.SetActive(false);
        }
    }
    
}
