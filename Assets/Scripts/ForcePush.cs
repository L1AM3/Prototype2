using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour
{
    public bool ForcePushing = false;
    public ForePushAnimation force;

    public void ForcePushes()
    {
        ForcePushing = true;
        force.ForcePushOne(ForcePushing);

        Invoke("Delay", 1);
    }

    private void Delay()
    {
        ForcePushing = false;
        force.ForcePushOne(ForcePushing);
    }
}
