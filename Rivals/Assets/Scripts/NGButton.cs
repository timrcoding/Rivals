using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NGButton : MonoBehaviour
{
    public int uniqueRef;
    public int reference;
    public TextMeshProUGUI text;
    void Start()
    {
        
    }

    public void incReference()
    {
        reference++;
        if(reference > NGQuiz.instance.quiz.Count)
        {
            reference = 0;
        }
        text.text = NGQuiz.instance.quiz[reference];
        NGQuiz.instance.checkAnswer(uniqueRef, reference);
    }
}
