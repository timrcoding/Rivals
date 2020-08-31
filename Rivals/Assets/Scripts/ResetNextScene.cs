using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class ResetNextScene : MonoBehaviour
{
    public static ResetNextScene instance;
    public bool gameFinished;
    public TextMeshProUGUI buttonText;
    void Start()
    {
        instance = this;
        
        transferToConfirmed();
    }

    public void resetRounds()
    {
        SaveManager.instance.activeSave.round.Clear();
        int correct = SaveManager.instance.activeSave.correctlyIdentified.Where(c => c).Count();
        SaveManager.instance.activeSave.roundCount = correct / 5;
    }

    public void incRoundCount()
    {
        SaveManager.instance.activeSave.roundCount++;
    }

    public void checkForFinish()
    {

        if (!SaveManager.instance.activeSave.correctlyIdentified.Contains(false))
        {
            gameFinished = true;
            buttonText.text = "Finish";
        }
        else
        {
            buttonText.text = "Continue";
        }
    }

    public void gameFinishLoad()
    {
        if (gameFinished)
        {
            StartCoroutine(GameResources.instance.TransitionOut(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else
        {
            AsyncLoad.instance.switchChangeLevel();
        }
    }

    public void transferToConfirmed()
    {
        foreach(int i in SaveManager.instance.activeSave.round)
        {
            SaveManager.instance.activeSave.correctlyIdentified[i] = true;
            SaveManager.instance.activeSave.submissionOrder.Add(i);
        }
        resetRounds();
        checkForFinish();
        SaveManager.instance.Save();
    }
}
