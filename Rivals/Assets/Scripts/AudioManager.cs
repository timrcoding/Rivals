using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource source;
    public AudioClip[] clips;
    void Start()
    {
        instance = this;
    }

    public void playClip(int i)
    {
        source.Stop();
        source.PlayOneShot(clips[i]);
    }
}
