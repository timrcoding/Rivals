using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoLoadScene : MonoBehaviour
{

    public AudioSource source;
    public AudioClip clip;
    public int level;
    public float audioTime;
    public float clipLength;
    public float specifiedClipLength;
    private void Update()
    {
        audioTime = source.time;
        clipLength = clip.length;
        loadScene();
    }

    public void loadScene()
    {
        if (specifiedClipLength == 0)
        {
            if (source.time >= clip.length)
            {
                AsyncLoad.instance.switchChangeLevel();
            }
        }
        else
        {
            if (source.time >= specifiedClipLength)
            {
                AsyncLoad.instance.switchChangeLevel();
            }
        }
    }
}
