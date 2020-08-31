using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmAudio : MonoBehaviour
{
    public static ConfirmAudio instance;
    public AudioClip[] bookClips;
    public AudioSource source;
    void Start()
    {
        instance = this;
        StartCoroutine(playClip());
    }

    public IEnumerator playClip()
    {
        yield return new WaitForSeconds(2);
        int num = SaveManager.instance.activeSave.submissionOrder[SaveManager.instance.activeSave.submissionOrder.Count - 1];
        source.PlayOneShot(bookClips[num]);
    }
}
