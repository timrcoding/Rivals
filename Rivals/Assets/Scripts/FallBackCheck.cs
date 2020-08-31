using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FallBackCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fallBack());
    }

    public IEnumerator fallBack()
    {
        yield return new WaitForSeconds(0.1f);
        if (!SaveManager.instance.activeSave.correctlyIdentified.Contains(false))
        {
            LevelLoader.instance.loadScene(4);
        }
    }
}
