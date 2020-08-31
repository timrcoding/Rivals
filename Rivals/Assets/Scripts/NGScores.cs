using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NGScores : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Start()
    {
        text.text = "You Scored " + NGQuiz.instance.score.ToString() + " Out of 15";

    }


}
