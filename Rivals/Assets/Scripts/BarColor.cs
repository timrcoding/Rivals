using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarColor : MonoBehaviour
{
    public float uniqueRef;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setColor();
    }

    public void setColor()
    {
        GetComponent<Image>().color = Color.HSVToRGB(uniqueRef / 100, 1, 1);
    }
}
