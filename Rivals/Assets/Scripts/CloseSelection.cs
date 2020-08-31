using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSelection : MonoBehaviour
{
    public GameObject selectionMenu;


    public void turnOff()
    {
        selectionMenu.SetActive(false);
    }
}
