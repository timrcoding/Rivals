using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Description : MonoBehaviour
{
    public static Description instance;

    public TextMeshProUGUI descriptionText;
    void Start()
    {
        instance = this;  
    }

    public void setDescription(int i)
    {
        descriptionText.text = GameResources.instance.descriptions[i];
        descriptionText.fontSizeMin = 35;
    }

    public void setContents(int i)
    {
        descriptionText.text = GameResources.instance.chapterContents[i];
        descriptionText.fontSizeMin = 1;
    }
}
