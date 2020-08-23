using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleInfo : MonoBehaviour
{
    public int uniqueRef;
    public TextMeshProUGUI titleText;
    void Start()
    {
        titleText.text = GameResources.instance.chapterTitles[uniqueRef];
    }

    public void chooseTitle()
    {
        PickAnswer.instance.titleRef = uniqueRef;
        PickAnswer.instance.compareAnswers();
        PickAnswer.instance.closeMenu();
        AudioManager.instance.PlayScribble();
    }

    public void setDescription()
    {
        Description.instance.setDescription(uniqueRef);
    }
}
