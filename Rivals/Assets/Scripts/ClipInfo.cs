using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipInfo : MonoBehaviour
{
    public int uniqueRef;
    public Animator anim;
    public void playClip()
    {
        anim.SetTrigger("Press");
        AudioManager.instance.playClip(uniqueRef);
        Debug.Log("PLAYIG CLIP");
    }
}
