using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAnimation : MonoBehaviour
{
    //Animator variable for laser animator
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Getting animator off of the laser
        anim = GetComponent<Animator>();
    }

    //Activating the bool in the laser animator
    public void LaserShootAnimation(bool LaserFire)
    {
        //Sets the bool according to what happens in third person controller script
        anim.SetBool("LaserFiring", LaserFire);
    }
}
