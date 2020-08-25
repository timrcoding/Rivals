using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleInfo : MonoBehaviour
{
    public int uniqueRef;
    public TextMeshProUGUI titleText;
    public bool pickable;
    public GameObject foreground;
    void Start()
    {
        titleText.text = GameResources.instance.chapterTitles[uniqueRef];
        checkIfTitleConfirmed();
    }

    public void checkIfTitleConfirmed()
    {
        if (SaveManager.instance.activeSave.correctlyIdentified[uniqueRef])
        {
            GetComponent<Button>().interactable = false;
            foreground.GetComponent<Image>().color = Color.clear;
            titleText.color = Color.black;
        }
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
