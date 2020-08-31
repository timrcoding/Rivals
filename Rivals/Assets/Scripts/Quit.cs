using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
   public void quitApp()
    {
        SaveManager.instance.Save();
        Application.Quit();
    }
}
