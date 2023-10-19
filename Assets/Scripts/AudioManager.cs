using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //Variables for the audio source and audio clip
    public AudioSource AudioSource;
    public AudioClip Audioclip;

    //Called when the player collects a health pickup
    public void PlayClip()
    {
        //Will stop any other audio clip from playing before starting this one
        AudioSource.Stop();

        //Setting audio source clip to audio clip and playing it
        AudioSource.clip = Audioclip;
        AudioSource.Play();
    }
}
