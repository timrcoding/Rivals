using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEnglarged : MonoBehaviour
{
    public GameObject enlargedObject;
    void Start()
    {
        enlargedObject.SetActive(false);
    }

    public void setObject()
    {
        enlargedObject.SetActive(true);
    }
}
