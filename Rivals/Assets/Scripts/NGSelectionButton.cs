using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class NGSelectionButton : MonoBehaviour
{
    public int uniqueRef;
    public int correctAnswer;
    public TextMeshProUGUI text;
    void Start()
    {
        text.text = NGQuiz.instance.names[uniqueRef];
        correctAnswer = NGQuiz.instance.correctAnswers[uniqueRef];
        
    }

    public void setRef()
    {
        NGQuiz.instance.answerProposed = correctAnswer;
        NGQuiz.instance.checkAnswer();
        NGQuiz.instance.choices[NGQuiz.instance.cluePicked].GetComponent<NGButton>().text.text = NGQuiz.instance.names[uniqueRef];
        NGQuiz.instance.switchOffNames();
    }
}
