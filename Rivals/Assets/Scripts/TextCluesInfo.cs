using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextCluesInfo : MonoBehaviour
{
    public int uniqueRef;
    public string Title;
    public TextMeshProUGUI TitleText;
    public List<string> bodyText;

    private void Start()
    {
        createList();
        setTitle();
    }

    public void setTitle()
    {
        TitleText.text = Title;
    }

    public void createList()
    {
        List<string> text = new List<string>(GameResources.instance.textCluesText[uniqueRef].text.Split('\n'));
        for (int i = 0; i < text.Count; i++)
        {
            if (i == 0)
            {
                Title = text[i];
            }
            else
            {
                bodyText.Add(text[i]);
            }
        }
    }

    public void setText()
    {
        StartCoroutine(resetScroll());
        AudioManager.instance.PlayPaper();
        GameObject Text = GameObject.FindGameObjectWithTag("BookText");
        TextMeshProUGUI text = Text.GetComponent<TextMeshProUGUI>();
        text.text = "";
        text.GetComponent<TextMeshProUGUI>().text += " " + '\n';
        foreach (string s in bodyText) {
            text.GetComponent<TextMeshProUGUI>().text += s + '\n' + '\n';
        }
    }

    public IEnumerator resetScroll()
    {
        yield return null;
        GameObject scroll = GameObject.FindGameObjectWithTag("Scroll");
        scroll.GetComponent<ScrollRect>().verticalNormalizedPosition = 1;

    }
}
