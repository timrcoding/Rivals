using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickOnOff : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        text.text = "Turn click off";
    }
    public void clickSwitch()
    {
        AudioManager.instance.clickOn = !AudioManager.instance.clickOn;
        if (AudioManager.instance.clickOn)
        {
            text.text = "Turn click off";
        }
        else
        {
            text.text = "Turn click on";
        }

    }
}
