using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAnimation : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void LaserShootAnimation(bool LaserFire)
    {
        anim.SetBool("LaserFiring", LaserFire);
    }
}
