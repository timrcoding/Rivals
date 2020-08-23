using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChapterInfo : MonoBehaviour
{
    public int uniqueRef;
    public bool picked;
    public int proposedRef;
    public TextMeshProUGUI title;
    public TextMeshProUGUI dateText;
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
        title.text = "Chapter " + (uniqueRef + 1).ToString();
    }

    public void animateButton()
    {
        GetComponent<Animator>().SetTrigger("Press");
        
    }

    public void chooseChapter()
    {
        PickAnswer.instance.openMenu();
        PickAnswer.instance.chapterRef = uniqueRef;
    }

    public void setChapterText(int i)
    {
        title.text = GameResources.instance.chapterTitles[i];
    }

    public void setDescription()
    {
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
