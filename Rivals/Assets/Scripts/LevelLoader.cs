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
}
