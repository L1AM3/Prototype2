using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinBotDamage : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PenguinBotHurtAnimatior(bool PenguinBotHurt)
    {
        anim.SetBool("PenguinBotHurt", PenguinBotHurt);
    }
}
