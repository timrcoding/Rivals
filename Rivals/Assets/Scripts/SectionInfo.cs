using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionInfo : MonoBehaviour
{
    public GameObject[] chapters;
    public int sectionRef;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSections()
    {
        for (int i = 0; i < chapters.Length; i++)
        {
            chapters[i].GetComponent<ChapterInfo>().uniqueRef = i + sectionRef * chapters.Length;
            chapters[i].GetComponent<ChapterInfo>().setChapterTitles();
        }
    }
}
