using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinBotDeathAnimation : MonoBehaviour
{
    //Animator variable for penguin bot death animator
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Getting animator off of the penguin bot head
        anim = GetComponent<Animator>();
    }

    //Activating the bool in the penguin bot head animator
    public void PenguinBotDeathAnimatior(bool PenguinBotDie)
    {
        //Sets the bool according to what happens in enemy health script
        anim.SetBool("PenguinBotDead", PenguinBotDie);
    }
}
