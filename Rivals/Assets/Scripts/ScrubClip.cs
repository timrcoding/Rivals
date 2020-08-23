using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrubClip : MonoBehaviour
{
    public bool rewind;
    public int speed;

    public void activateScrub()
    {
        StartCoroutine(scrub());
    }

    public IEnumerator scrub()
    {
        AudioManager.instance.playClick();
        if (rewind)
        {
            AudioManager.instance.source.pitch = -speed;
        }
        else
        {
            AudioManager.instance.source.pitch = speed;
        }
        yield return new WaitForSeconds(1.5f);
        AudioManager.instance.source.pitch = 1;
        AudioManager.instance.playClick();
    }
}
