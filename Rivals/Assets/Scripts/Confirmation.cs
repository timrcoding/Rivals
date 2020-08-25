using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Confirmation : MonoBehaviour
{
    public GameObject[] confirmationObjects;

    void Start()
    {
        setObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setObjects()
    {
        for(int i = 0; i < 5; i++)
        {
            confirmationObjects[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = GameResources.instance.chapterTitles[SaveManager.instance.activeSave.round[i]];
            confirmationObjects[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GameResources.instance.descriptions[SaveManager.instance.activeSave.round[i]];
        }
    }
}
