using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarAnimation : MonoBehaviour
{
    //Animator variable for health bar animator
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Getting animator off of the health bar
        anim = GetComponent<Animator>();
    }

    //Activating the bool in the health bar animator 
    public void PenguinHealthBarAnimation(bool HealthBarAppearing)
    {
        //Sets the bool according to what happens in player health script
        anim.SetBool("HealthBarAppear", HealthBarAppearing);
    }
}
