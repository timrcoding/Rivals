using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    private void Start()
    {
        instance = this;
    }
    public void loadScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void prevScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void gameFinishLoad()
    {
        if (ResetNextScene.instance.gameFinished)
        {
            StartCoroutine(GameResources.instance.TransitionOut(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else
        {
            StartCoroutine(GameResources.instance.TransitionOut(SceneManager.GetActiveScene().buildIndex - 1));
        }
    }
}
