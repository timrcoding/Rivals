using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipInfo : MonoBehaviour
{
    public int uniqueRef;
    public void playClip()
    {
        AudioManager.instance.playClip(uniqueRef);
    }
}
