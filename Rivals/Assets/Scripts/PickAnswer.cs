using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using System.Linq;

public class PickAnswer : MonoBehaviour
{
    public static PickAnswer instance;
    public int chapterRef;
    public int titleRef;
    public List<int> correctAnswers;
    void Start()
    {
        instance = this;
        colorChosenTitles();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openMenu()
    {
        GameResources.instance.selectionMenu.SetActive(true);
        
    }

    public void closeMenu()
    {
        GameResources.instance.selectionMenu.SetActive(false);
    }

    public void compareAnswers()
    {
        if(chapterRef == titleRef)
        {
            if (!SaveManager.instance.activeSave.round.Contains(chapterRef))
            {
                SaveManager.instance.activeSave.round.Add(chapterRef);
            }
        }
        else
        {  
                SaveManager.instance.activeSave.round.Remove(chapterRef);
                
            
        }

        setAnswer();
    }

    public void clearChapter()
    {
        SaveManager.instance.activeSave.proposedNames[chapterRef] = 99;
        GameResources.instance.chapters[chapterRef].GetComponent<ChapterInfo>().setChapterTitles();
        colorChosenTitles();
        if (SaveManager.instance.activeSave.round.Contains(chapterRef))
        {
            SaveManager.instance.activeSave.round.Remove(chapterRef);
        }
    }

    public void setAnswer()
    {
        GameResources.instance.chapters[chapterRef].GetComponent<ChapterInfo>().setChapterText(titleRef);
        GameResources.instance.chapters[chapterRef].GetComponent<ChapterInfo>().proposedRef = titleRef;
        SaveManager.instance.activeSave.proposedNames[chapterRef] = titleRef;
        GameResources.instance.chapters[chapterRef].GetComponent<ChapterInfo>().picked = true;
        checkForRoundCompletion();
    }

    public void checkForRoundCompletion()
    {
        if(SaveManager.instance.activeSave.round.Count >= 5)
        {
            SaveManager.instance.Save();
            StartCoroutine(GameResources.instance.TransitionOut(3));
        }
    }

    public void colorChosenTitles()
    {
        for (int i = 0; i < SaveManager.instance.activeSave.proposedNames.Length; i++)
        {
            GameResources.instance.chapterTitleButtons[i].GetComponent<TitleInfo>().titleText.color = Color.white;
            if (SaveManager.instance.activeSave.proposedNames.Contains(i) && !SaveManager.instance.activeSave.correctlyIdentified[i]) 
            {
                GameResources.instance.chapterTitleButtons[i].GetComponent<TitleInfo>().titleText.color = Color.red;
            }
            else if (SaveManager.instance.activeSave.correctlyIdentified[i])
            {
                GameResources.instance.chapterTitleButtons[i].GetComponent<TitleInfo>().titleText.color = Color.black;
            }

        }
    }
}
