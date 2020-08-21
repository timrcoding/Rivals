using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResources : MonoBehaviour
{
    public static GameResources instance;

    [SerializeField]
    private TextAsset chapterTitlesText;
    public List<string> chapterTitles;
    public GameObject[] chapters;

    void Start()
    {
        instance = this;
        setChapters();
        setSections();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setChapters()
    {
        chapterTitles = new List<string>(chapterTitlesText.text.Split('\n'));
    }

    public void setSections()
    {
        foreach (GameObject g in GameResources.instance.chapters)
        {
            g.GetComponent<SectionInfo>().setSections();
            if(g.GetComponent<SectionInfo>().sectionRef == 0)
            {
                g.SetActive(true);
            }
            else
            {
                g.SetActive(false);
            }
        }
    }
}
