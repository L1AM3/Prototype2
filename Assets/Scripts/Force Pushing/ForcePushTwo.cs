using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePushTwo : MonoBehaviour
{
    //bool to see if the player is force pushing
    public bool ForcePushing = false;

    //public reference to force push animation
    public ForcePushTwoAnimation Force;

    public void ForcePushes()
    {
        //If the force push function is called the animation bool will be set to true and will play
        ForcePushing = true;
        Force.ForcePushingAnimation(ForcePushing);

        //Reverts back to default animation when done
        Invoke("Delay", 1);
    }

    private void Delay()
    {
        //If the force push function is done the animation bool will be set to false and will stop playing
        ForcePushing = false;
        Force.ForcePushingAnimation(ForcePushing);
    }
}
