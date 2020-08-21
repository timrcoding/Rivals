using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChapter : MonoBehaviour
{
    public static SelectChapter instance;

    public int chapterSelection;

    void Start()
    {
        instance = this;
        ChapterSelection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incChapter()
    {
        chapterSelection++;
        ChapterSelection();
    }

    public void ChapterSelection()
    {
        if(chapterSelection >= GameResources.instance.chapters.Length)
        {
            chapterSelection = 0;
        }
        foreach (GameObject g in GameResources.instance.chapters)
        {
            g.SetActive(false);
        }
        GameResources.instance.chapters[chapterSelection].SetActive(true);
    }
}
