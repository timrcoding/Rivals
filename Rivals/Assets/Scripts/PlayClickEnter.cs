﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClickEnter : MonoBehaviour
{
    public void playClick()
    {
        AudioManager.instance.playRollover();
    }
}
