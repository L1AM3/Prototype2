using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class CinematicCameraTrigger : MonoBehaviour
{
    //bool for whether the cinematic can play or not
    public bool CanPlay = true;

    //Variables for getting the cinematic director and a reference to the player controller
    private PlayableDirector cinematicDirector;
    private ThirdPersonCharacterController playerReference;

    private void Awake()
    {
        //Getting the playable director component
        cinematicDirector = GetComponent<PlayableDirector>();

        //Subscribing to cinematic director event
        cinematicDirector.stopped += CinematicDirectorStopped;
    }

    void CinematicDirectorStopped(PlayableDirector PlayDirector)
    {
        //Player can control character if the play director is stopped
        if (cinematicDirector == PlayDirector)
        {
            playerReference.canControl = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player collides with trigger and the cinematic can play then it will
        if(other.tag == "Player" && CanPlay)
        {
            //Setting the player reference to the third person controller component
            playerReference = other.GetComponent<ThirdPersonCharacterController>();

            //The cinematic plays
            cinematicDirector.Play();

            //The player can't control their character during this cinematic
            playerReference.canControl = false;

            //The cinematic can no longer be played
            CanPlay = false;
        }
    }
}
