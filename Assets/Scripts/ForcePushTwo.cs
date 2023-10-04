using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePushTwo : MonoBehaviour
{
    public bool ForcePushing = false;
    public ForcePushTwoAnimation force;

    public void ForcePushes()
    {
        ForcePushing = true;
        force.ForcePushingAnimation(ForcePushing);

        Invoke("Delay", 1);
    }

    private void Delay()
    {
        ForcePushing = false;
        force.ForcePushingAnimation(ForcePushing);
    }
}
