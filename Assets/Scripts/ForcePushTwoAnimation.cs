using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePushTwoAnimation : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ForcePushingAnimation(bool ForcePushedTwo)
    {
        anim.SetBool("IsForcePushTwo", ForcePushedTwo);
    }

}
