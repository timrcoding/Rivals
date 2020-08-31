using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTrack : MonoBehaviour
{
    public int uniqueRef;
    public AudioClip clip;
    public Animator anim;
    public float volume;
    public void playClip()
    {
        AudioManager.instance.playClip(clip,volume,uniqueRef);
        //animateClip();
    }

    public void animateClip()
    {
        GetComponent<Animator>().SetTrigger("Press");
    }
}
