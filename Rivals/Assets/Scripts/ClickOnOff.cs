using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickOnOff : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        StartCoroutine(setClickSwitch());
    }
    public void clickSwitch()
    {
        AudioManager.instance.clickOn = !AudioManager.instance.clickOn;
        if (SaveManager.instance != null)
        {
            SaveManager.instance.activeSave.click = AudioManager.instance.clickOn;
            SaveManager.instance.Save();
        }
        if (AudioManager.instance.clickOn)
        {
            text.text = "Sound Effects off";
        }
        else
        {
            text.text = "Sound Effects on";
        }

    }

    public IEnumerator setClickSwitch()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        if (AudioManager.instance.clickOn)
        {
            text.text = "Sound Effects off";
        }
        else
        {
            text.text = "Sound Effects on";
        }
    }
}
