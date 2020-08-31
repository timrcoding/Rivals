using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Rounds : MonoBehaviour
{
    public static Rounds instance;
    public int round;
    public GameObject[] rounds;
    void awake()
    {
        instance = this;
        
    }

    private void Start()
    {
        initializeObjects();
        PlayerPrefs.SetInt("Continue", 1);
    }

    public void initializeObjects()
    {
        foreach(GameObject g in rounds)
        {
            g.SetActive(false);
        }
        setRounds();

    }

    public void setRounds()
    {
        round = SaveManager.instance.activeSave.roundCount;
        for(int i = 0; i < rounds.Length; i++)
        {
            if(i <= round)
            {
                rounds[i].SetActive(true);
            }
            else
            {
                rounds[i].SetActive(false);
            }
        }
        checkForRoundError();
    }

    public void checkForRoundError()
    {
        int  num = SaveManager.instance.activeSave.correctlyIdentified.Where(c => c).Count();
        int length = SaveManager.instance.activeSave.submissionOrder.Count;
        Debug.Log("CORRECT: " + num);
        Debug.Log("Length;" + length);
        if(num%5 != 0)
        {
            Debug.Log("Round Error");
            int lastEntry = SaveManager.instance.activeSave.submissionOrder[SaveManager.instance.activeSave.submissionOrder.Count-1];
            SaveManager.instance.activeSave.submissionOrder.RemoveAt(SaveManager.instance.activeSave.submissionOrder.Count - 1);
            SaveManager.instance.activeSave.correctlyIdentified[lastEntry] = false;
            SaveManager.instance.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Debug.Log("No Error");
            Debug.Log("SCENE LOADED");
        }
    }

    
}
