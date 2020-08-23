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
                correctAnswers.Add(chapterRef);
            }
        }
        else
        {
            if (correctAnswers.Contains(chapterRef))
            {
                correctAnswers.Remove(chapterRef);
            }
        }

        setAnswer();
    }

    public void setAnswer()
    {
        GameResources.instance.chapters[chapterRef].GetComponent<ChapterInfo>().setChapterText(titleRef);
        GameResources.instance.chapters[chapterRef].GetComponent<ChapterInfo>().proposedRef = titleRef;
        GameResources.instance.chapters[chapterRef].GetComponent<ChapterInfo>().picked = true;
        checkForRoundCompletion();
    }

    public void checkForRoundCompletion()
    {
        if(correctAnswers.Count == 5)
        {
            Debug.Log("ROUND COMPLETE");
        }
    }
}
