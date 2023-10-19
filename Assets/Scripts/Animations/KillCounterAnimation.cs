using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounterAnimation : MonoBehaviour
{
    //Animator variable for kill counter animator
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Getting animator off of the kill counter
        anim = GetComponent<Animator>();
    }

    //Activating the bool in the kill counter animator
    public void KillerCounterAnimation(bool EnemyWasKilled)
    {
        //Sets the bool according to what happens in kill counter script
        anim.SetBool("EnemyKilled", EnemyWasKilled);
    }
}
