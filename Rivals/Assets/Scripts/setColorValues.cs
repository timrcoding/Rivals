using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class setColorValues : MonoBehaviour
{
    public Image[] bars;
    void Start()
    {
        for(int i = 0; i < bars.Length; i++)
        {
            float num = i;
            bars[i].GetComponent<BarColor>().uniqueRef = num;
            bars[i].GetComponent<BarColor>().setColor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
