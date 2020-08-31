using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class NGQuiz : MonoBehaviour
{
    public static NGQuiz instance;

    public TextAsset quizText;
    public List<string> quiz;
    public TextAsset answerText;
    public List<string> correctAnswers;
    public List<bool> checkedCorrect;
    public int score;
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
        correctAnswers = new List<string>(answerText.text.Split('\n'));

        
    }

    public void checkAnswer(int uniqueRef, int reference)
    {
       if (System.Convert.ToInt32(correctAnswers[uniqueRef]) == reference)
        {
            checkedCorrect[uniqueRef] = true;
        }
        else
        {
            checkedCorrect[uniqueRef] = false;
        }
        setScore();
    }

    public void setScore()
    {
        score = checkedCorrect.Where(c => c).Count();
    }
    
}
