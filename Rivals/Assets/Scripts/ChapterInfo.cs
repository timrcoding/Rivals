using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChapterInfo : MonoBehaviour
{
    public int uniqueRef;
    public TextMeshProUGUI title;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setChapterTitles()
    {
        title.text = "Chapter " + (uniqueRef + 1).ToString();
    }

    public void animateButton()
    {
        GetComponent<Animator>().SetTrigger("Press");
        title.text = GameResources.instance.chapterTitles[uniqueRef];
    }
}
