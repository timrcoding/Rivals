using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setContinue : MonoBehaviour
{
    public GameObject continueOption;
    public GameObject NG;
    void Start()
    {
        PlayerPrefs.GetInt("Continue", 0);
        if(PlayerPrefs.GetInt("Continue") == 0)
        {
            continueOption.GetComponent<Button>().interactable = false;
            continueOption.GetComponent<Image>().color = Color.grey;
            Debug.Log("NG NOT ACTIVE");
            
        }
        else
        {
            continueOption.GetComponent<Button>().interactable = true;
            continueOption.GetComponent<Image>().color = Color.white;
        }

        PlayerPrefs.GetInt("NG", 0);
        if (PlayerPrefs.GetInt("NG") == 0)
        {
            NG.GetComponent<Button>().interactable = false;
            NG.GetComponent<Image>().color = Color.grey;
            Debug.Log("NG NOT ACTIVE");
        }
        else
        {
            NG.GetComponent<Button>().interactable = true;
            NG.GetComponent<Image>().color = Color.white;
            Debug.Log("NG IS ACTIVE");
        }
    }

    
}
