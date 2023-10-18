using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarAnimation : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PenguinHealthBarAnimation(bool HealthBarAppearing)
    {
        anim.SetBool("HealthBarAppear", HealthBarAppearing);
    }
}
