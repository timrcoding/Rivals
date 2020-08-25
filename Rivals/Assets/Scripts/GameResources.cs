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
        setTextAssets();
        GameResources.instance.setChapters();
        GameResources.instance.setTitleRef();
        GameResources.instance.setTextClues();
        StartCoroutine(GameResources.instance.saveGame());
        
        
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
            if (chapters[i] != null)
            {
                chapters[i].GetComponent<ChapterInfo>().uniqueRef = i;
            }
        }
    }

    public void setTextClues()
    {
        for(int i = 0; i < textClues.Length; i++)
        {
            if (textClues[i] != null)
            {
                textClues[i].GetComponent<TextCluesInfo>().uniqueRef = i;
            }
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
        if (chapters != null)
        {
            for (int i = 0; i < chapterTitles.Count; i++)
            {
                
                    chapters[i].GetComponent<ChapterInfo>().uniqueRef = i;
                    chapterTitleButtons[i].GetComponent<TitleInfo>().uniqueRef = i;
            }
        }
    }

    public IEnumerator saveGame()
    {
        SaveManager.instance.Save();
        yield return new WaitForSeconds(5);
        StartCoroutine(saveGame());
    }
}
