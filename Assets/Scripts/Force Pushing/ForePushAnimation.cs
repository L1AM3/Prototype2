using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForePushAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ForcePushOne(bool ForcePushing)
    {
        anim.SetBool("IsForcePush", ForcePushing);
    }
}
