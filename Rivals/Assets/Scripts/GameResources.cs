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
    [SerializeField]
    private TextAsset chapterContentsText;
    [SerializeField]
    private TextAsset nowPlayingText;
    public List<string> chapterTitles;
    public List<string> chapterDates;
    public List<string> descriptions;
    public List<string> chapterContents;
    public List<string> nowPlaying;
    public GameObject[] sections;
    public GameObject[] chapters;
    public GameObject[] chapterTitleButtons;
  

    public TextAsset[] textCluesText;
    public GameObject[] textClues;
    public GameObject[] cassettes;

    public GameObject transitionIn;
    public GameObject transitionOut;


    public GameObject selectionMenu;

    void Awake()
    {
        instance = this;
        
        setTextAssets();
        GameResources.instance.setChapters();
        GameResources.instance.setTitleRef();
        GameResources.instance.setTextClues();
        PlayerPrefs.SetInt("Continue", 1);


    }

    private void Start()
    {
        StartCoroutine(TransitionIn());
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
        chapterContents = new List<string>(chapterContentsText.text.Split('\n'));
        nowPlaying = new List<string>(nowPlayingText.text.Split('\n'));
    }

    public void setTitleRef()
    {
        if (chapters.Length != 0)
        {
            for (int i = 0; i < chapterTitles.Count-1; i++)
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

    public IEnumerator TransitionIn()
    {
        transitionIn.SetActive(true);
        yield return new WaitForSeconds(2f);
        transitionIn.SetActive(false);
    }

    public IEnumerator TransitionOut(int i)
    {
        transitionOut.SetActive(true);
        yield return new WaitForSeconds(2f);
        LevelLoader.instance.loadScene(i);
    }

}
