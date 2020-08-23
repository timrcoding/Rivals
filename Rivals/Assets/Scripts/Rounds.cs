using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Rounds : MonoBehaviour
{
    public static Rounds instance;
    public int round;
    public GameObject[] rounds;
    void Start()
    {
        instance = this;
        initializeObjects();
    }

    public void initializeObjects()
    {
        foreach(GameObject g in rounds)
        {
            g.SetActive(false);
        }
        setRounds();

    }

    public void setRounds()
    {
        for(int i = 0; i < rounds.Length; i++)
        {
            if(i < round)
            {
                rounds[i].SetActive(true);
            }
            else
            {
                rounds[i].SetActive(false);
            }
        }
    }

    
}
