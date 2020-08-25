using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource source;
    public AudioSource sfx;
    public AudioClip[] clips;


    public AudioClip cassetteLoad;
    public AudioClip cassetteClick;
    public AudioClip paper;
    public AudioClip scribble;
    void Start()
    {
        instance = this;
    }

    public void playClip(AudioClip clip)
    {
        source.Stop();
        source.PlayOneShot(clip);
        sfx.PlayOneShot(cassetteLoad);
    }

    public void playClick()
    {
        sfx.PlayOneShot(cassetteClick);
    }

    public void PlayPaper()
    {
        sfx.PlayOneShot(paper);
    }

    public void PlayScribble()
    {
        sfx.PlayOneShot(scribble);
    }
}
