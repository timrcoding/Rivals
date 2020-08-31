using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChapterInfo : MonoBehaviour
{
    public int uniqueRef;
    public bool picked;
    public int proposedRef;
    public TextMeshProUGUI title;
    public TextMeshProUGUI dateText;
    public GameObject foreground;
    void Start()
    {
        setChapterTitles();
        setDates();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDates()
    {
        dateText.text = GameResources.instance.chapterDates[uniqueRef];
    }

    public void setChapterTitles()
    {
        if (SaveManager.instance.activeSave.proposedNames[uniqueRef] == 99)
        {
            title.text = "Chapter " + (uniqueRef + 1).ToString();
        }
        else
        {
            title.text = GameResources.instance.chapterTitles[SaveManager.instance.activeSave.proposedNames[uniqueRef]];
        }
        checkIfChapterConfirmed();
    }

    public void checkIfChapterConfirmed()
    {
        if (SaveManager.instance.activeSave.correctlyIdentified[uniqueRef])
        {
            picked = true;
            proposedRef = uniqueRef;
            GetComponent<Button>().interactable = false;
            foreground.GetComponent<Image>().color = Color.clear;
            title.color = Color.white;
            GetComponent<TextColorChange>().origColor = Color.white;
        }
        else
        {
            GetComponent<TextColorChange>().origColor = Color.black;
        }
    }

    public void animateButton()
    {
        GetComponent<Animator>().SetTrigger("Press");
        
    }

    public void chooseChapter()
    {
        PickAnswer.instance.openMenu();
        PickAnswer.instance.chapterRef = uniqueRef;
        AudioManager.instance.PlayPaper();
    }

    public void setChapterText(int i)
    {
        title.text = GameResources.instance.chapterTitles[i];
    }

    public void setDescription()
    {
        if (AudioManager.instance.clickOn)
        {
            AudioManager.instance.sfx.PlayOneShot(AudioManager.instance.entryClick);
        }
        if (picked)
        {
            Description.instance.setDescription(proposedRef);
        }
        else
        {
            Description.instance.descriptionText.text = "Click to select a chapter";
        }
    }
}
