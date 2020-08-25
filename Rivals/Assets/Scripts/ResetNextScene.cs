using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetNextScene : MonoBehaviour
{
    public static ResetNextScene instance;
    void Start()
    {
        instance = this;
    }

    public void resetRounds()
    {
        SaveManager.instance.activeSave.round.Clear();
    }

    public void incRoundCount()
    {
        SaveManager.instance.activeSave.roundCount++;
    }

    public void transferToConfirmed()
    {
        foreach(int i in SaveManager.instance.activeSave.round)
        {
            SaveManager.instance.activeSave.correctlyIdentified[i] = true;
        }
        resetRounds();
        incRoundCount();
        SaveManager.instance.Save();
    }
}
