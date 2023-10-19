using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForePushAnimation : MonoBehaviour
{
    //Animator variable penguin arm one animator
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Getting animator off of the penguin arm one
        anim = GetComponent<Animator>();
    }

    //Activating the bool in the penguin arm one animator
    public void ForcePushOne(bool ForcePushing)
    {
        //Sets the bool according to what happens in force push one script
        anim.SetBool("IsForcePush", ForcePushing);
    }
}
