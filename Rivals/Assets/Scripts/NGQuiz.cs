using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class NGQuiz : MonoBehaviour
{
    public static NGQuiz instance;

    public TextAsset namesText;
    public List<string> names;

    public TextAsset quizText;
    public List<string> quiz;
    public TextAsset answerText;
    public List<int> correctAnswers;
    public List<bool> checkedCorrect;
    public int score;
    public List<GameObject> selectionButtons;
    public List<GameObject> choices;

    public int cluePicked;
    public int answerProposed;

    public GameObject nameSelection;
    public GameObject bookImage;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        quiz = new List<string>(quizText.text.Split('\n'));
        
        names = new List<string>(namesText.text.Split('\n'));

        for(int i = 0; i < selectionButtons.Count; i++)
        {
            choices[i].GetComponent<NGButton>().uniqueRef = i;
            selectionButtons[i].GetComponent<NGSelectionButton>().uniqueRef = i;
            
        }
        switchOffNames();
    }

    public void checkAnswer()
    {
       if (cluePicked == answerProposed)
        {
            checkedCorrect[cluePicked] = true;
            Debug.Log("CORRECT");
        }
        else
        {
            checkedCorrect[cluePicked] = false;
            Debug.Log("WRONG");
        }
        setScore();
    }

    public void setScore()
    {
        score = checkedCorrect.Where(c => c).Count();
    }

    public void switchOnNames()
    {
        nameSelection.SetActive(true);
        bookImage.SetActive(true);
    }

    public void switchOffNames()
    {
        nameSelection.SetActive(false);
        bookImage.SetActive(false);
    }
}
