using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePushTwoAnimation : MonoBehaviour
{
    //Animator variable penguin arm two animator
    private Animator anim;

    private void Start()
    {
        //Getting animator off of the penguin arm two
        anim = GetComponent<Animator>();
    }

    //Activating the bool in the penguin arm two animator
    public void ForcePushingAnimation(bool ForcePushedTwo)
    {
        //Sets the bool according to what happens in force push two script
        anim.SetBool("IsForcePushTwo", ForcePushedTwo);
    }

}
