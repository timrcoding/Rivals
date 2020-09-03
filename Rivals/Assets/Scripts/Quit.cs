using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
   public void quitApp()
    {
        if (SaveManager.instance != null)
        {
            SaveManager.instance.Save();
        }
        Debug.Log("Quit");
        Application.Quit();
    }
}
