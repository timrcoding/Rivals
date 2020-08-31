using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextColorChange : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Color origColor;

    private void Start()
    {
        StartCoroutine(setOrigColor());
    }

    public void textColorRed()
    {
        text.color = Color.red;
    }

    public void textColorWhite()
    {
        text.color = Color.white;
    }

    public void textColorBlack()
    {
        text.color = Color.black;
    }

    public void originalColor()
    {
        text.color = origColor;
    }

    public void playClick()
    {
        AudioManager.instance.playRollover();
    }

    public IEnumerator setOrigColor()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Orig Color Set");
        origColor = text.color;
    }
}
