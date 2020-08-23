using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopClip : MonoBehaviour
{
    public void stopClip()
    {
        AudioManager.instance.source.Stop();
        AudioManager.instance.playClick();
    }
}
