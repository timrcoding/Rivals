using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NGButton : MonoBehaviour
{
    public int uniqueRef;
    public TextMeshProUGUI text;
    void Start()
    {
        
    }

    public void incReference()
    {
        NGQuiz.instance.switchOnNames();
        NGQuiz.instance.cluePicked = uniqueRef;
    }
}
