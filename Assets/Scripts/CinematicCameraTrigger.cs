using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class CinematicCameraTrigger : MonoBehaviour
{
    public bool canPlay = true;

    private PlayableDirector cinematicDirector;
    private ThirdPersonCharacterController playerReference;

    private void Awake()
    {
        cinematicDirector = GetComponent<PlayableDirector>();

        cinematicDirector.stopped += CinematicDirectorStopped;
    }

    void CinematicDirectorStopped(PlayableDirector PlayDirector)
    {
        if (cinematicDirector == PlayDirector)
        {
            playerReference.canControl = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && canPlay)
        {
            playerReference = other.GetComponent<ThirdPersonCharacterController>();

            cinematicDirector.Play();

            playerReference.canControl = false;

            canPlay = false;
        }
    }
}
