using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinBotDeathAnimation : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PenguinBotDeathAnimatior(bool PenguinBotDie)
    {
        anim.SetBool("PenguinBotDead", PenguinBotDie);
    }
}