using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResources : MonoBehaviour
{
    public static GameResources instance;

    [SerializeField]
    private TextAsset chapterTitlesText;
    [SerializeField]
    private TextAsset chapterDatesText;
    [SerializeField]
    private TextAsset descriptionText;
    public List<string> chapterTitles;
    public List<string> chapterDates;
    public List<string> descriptions;
    public GameObject[] sections;
    public GameObject[] chapters;
    public GameObject[] chapterTitleButtons;

    public TextAsset[] textCluesText;
    public GameObject[] textClues;
    public GameObject[] cassettes;

    public GameObject selectionMenu;

    void Awake()
    {
        instance = this;
        //PickAnswer.instance.openMenu();
        setChapters();
        setTextAssets();
        setTitleRef();
        setTextClues();
        //PickAnswer.instance.closeMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCassettes()
    {
        for (int i = 0; i < cassettes.Length; i++)
        {
            cassettes[i].GetComponent<ClipInfo>().uniqueRef = i;
        }
    }

    public void setChapters()
    {
        for(int i = 0; i < chapters.Length; i++)
        {
            chapters[i].GetComponent<ChapterInfo>().uniqueRef = i;
        }
    }

    public void setTextClues()
    {
        for(int i = 0; i < textClues.Length; i++)
        {
            textClues[i].GetComponent<TextCluesInfo>().uniqueRef = i;
        }
    }

    public void setTextAssets()
    {
        chapterTitles = new List<string>(chapterTitlesText.text.Split('\n'));
        chapterDates = new List<string>(chapterDatesText.text.Split('\n'));
        descriptions = new List<string>(descriptionText.text.Split('\n'));
    }

    public void setTitleRef()
    {
        for(int i = 0; i < chapterTitles.Count; i++)
        {
            chapters[i].GetComponent<ChapterInfo>().uniqueRef = i;
            chapterTitleButtons[i].GetComponent<TitleInfo>().uniqueRef = i; 
        }
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
