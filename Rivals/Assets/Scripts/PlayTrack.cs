using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTrack : MonoBehaviour
{
    public AudioClip clip;
    public void playClip()
    {
        AudioManager.instance.playClip(clip);
        Debug.Log("TRACK PLAYING");
    }
}
