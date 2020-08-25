using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PickAnswer : MonoBehaviour
{
    public static PickAnswer instance;
    public int chapterRef;
    public int titleRef;
    public List<int> correctAnswers;
    void Start()
    {
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openMenu()
    {
        Debug.Log("OPEN");
        GameResources.instance.selectionMenu.SetActive(true);
        
    }

    public void closeMenu()
    {
        Debug.Log("CLOSE");
        GameResources.instance.selectionMenu.SetActive(false);
    }

    public void compareAnswers()
    {
        if(chapterRef == titleRef)
        {
            if (!correctAnswers.Contains(chapterRef))
            {
                SaveManager.instance.activeSave.round.Add(chapterRef);
            }
        }
        else
        {
            if (correctAnswers.Contains(chapterRef))
            {
                SaveManager.instance.activeSave.round.Remove(chapterRef);
            }
        }

        setAnswer();
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
            LevelLoader.instance.loadScene(1);
        }
    }
}
