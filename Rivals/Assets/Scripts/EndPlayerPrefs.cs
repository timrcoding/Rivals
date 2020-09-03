using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlayerPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SaveManager.instance.deleteData();
        PlayerPrefs.SetInt("Continue", 0);
        PlayerPrefs.SetInt("NG", 1);
    }

}
