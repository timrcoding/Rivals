using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public void shake()
    {
        Debug.Log("Shake");
        GetComponent<Animator>().SetTrigger("Shake");
    }

    public void playClick()
    {
        if (AudioManager.instance.clickOn)
        {
            AudioManager.instance.sfx.PlayOneShot(AudioManager.instance.entryClick);
        }
    }
}
