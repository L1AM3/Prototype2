using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinBotDamage : MonoBehaviour
{
    //Animator variable for penguin damage animator
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Getting animator off of the penguin bot eyes
        anim = GetComponent<Animator>();
    }

    //Activating the bool in the penguin bot eye animator
    public void PenguinBotHurtAnimatior(bool PenguinBotHurt)
    {
        //Sets the bool according to what happens in enemy health script
        anim.SetBool("PenguinBotHurt", PenguinBotHurt);
    }
}
