using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLucy : MonoBehaviour
{
    public GameObject Lucy;
    void Start()
    {
       StartCoroutine(playLucy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator playLucy()
    {
        yield return new WaitForSeconds(.1f);
        Lucy.GetComponent<PlayTrack>().playClip();
        Debug.Log("PLAYING LUCY");
    }
}
