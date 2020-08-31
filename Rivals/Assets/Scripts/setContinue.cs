using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setContinue : MonoBehaviour
{
    public GameObject continueOption;
    public GameObject NG;
    void Start()
    {
        PlayerPrefs.GetInt("Continue", 0);
        if(PlayerPrefs.GetInt("Continue") != 0)
        {
            continueOption.SetActive(true);
        }
        else
        {
            continueOption.SetActive(false);
        }

        PlayerPrefs.GetInt("NG", 0);
        if (PlayerPrefs.GetInt("NG") != 0)
        {
            NG.SetActive(true);
        }
        else
        {
            NG.SetActive(false);
        }
    }

    
}
