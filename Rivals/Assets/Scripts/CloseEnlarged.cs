using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEnlarged : MonoBehaviour
{
    public GameObject enlargedObject;
    public void closeObject()
    {
        enlargedObject.SetActive(false);
    }
}
