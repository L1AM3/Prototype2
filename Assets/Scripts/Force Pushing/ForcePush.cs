using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour
{
    //bool to see if the player is force pushing
    public bool ForcePushing = false;

    //public reference to force push animation
    public ForePushAnimation Force;

    public void ForcePushes()
    {
        //If the force push function is called the animation bool will be set to true and will play
        ForcePushing = true;
        Force.ForcePushOne(ForcePushing);

        //Reverts back to default animation when done
        Invoke("Delay", 1);
    }

    public void Delay()
    {
        //If the force push function is done the animation bool will be set to false and will stop playing
        ForcePushing = false;
        Force.ForcePushOne(ForcePushing);
    }
}
