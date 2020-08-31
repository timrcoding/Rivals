using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WipeData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        deleteData();
    }

    public void deleteData()
    {
        PlayerPrefs.SetInt("Continue", 0);
        PlayerPrefs.SetInt("NG", 1);
        for (int i = 0; i < SaveManager.instance.activeSave.correctlyIdentified.Length; i++)
        {
            SaveManager.instance.activeSave.correctlyIdentified[i] = false;
            SaveManager.instance.activeSave.proposedNames[i] = 99;
        }

        SaveManager.instance.activeSave.submissionOrder.Clear();
        SaveManager.instance.activeSave.round.Clear();
        
       
    }
}
