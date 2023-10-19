using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip Audioclip;

    public void PlayClip()
    {
        AudioSource.Stop();
        AudioSource.clip = Audioclip;
        AudioSource.Play();
    }
}
