using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WipeData : MonoBehaviour
{
    public static WipeData instance;
    void Start()
    {
        instance = this;
    }

    public void deleteData()
    {

        if (SaveManager.instance != null)
        {

            for (int i = 0; i < SaveManager.instance.activeSave.correctlyIdentified.Length; i++)
            {
                SaveManager.instance.activeSave.correctlyIdentified[i] = false;
                SaveManager.instance.activeSave.proposedNames[i] = 99;
            }

            SaveManager.instance.activeSave.submissionOrder.Clear();
            SaveManager.instance.activeSave.round.Clear();
            Destroy(gameObject);
        }
        


    }
}
