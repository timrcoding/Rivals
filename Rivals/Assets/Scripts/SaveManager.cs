using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class SaveManager : MonoBehaviour
{

    public static SaveManager instance;

    public saveData activeSave;

    public bool hasLoaded;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        
        GameObject singleton = GameObject.FindGameObjectWithTag("Singleton");
        if (singleton != null)
        {
            deleteSaveData();
            Save();
            Load();
            Destroy(singleton);
        }
        else
        {
            Load();
        }
        StartCoroutine(GameResources.instance.saveGame());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save()
    {
        string dataPath = Application.persistentDataPath;
        var serializer = new XmlSerializer(typeof(saveData));
        var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();
        Debug.Log("Saved");
    }
    public void Load()
    {
        string dataPath = Application.persistentDataPath;
        if (System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            var serializer = new XmlSerializer(typeof(saveData));
            var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Open);
            activeSave = serializer.Deserialize(stream) as saveData;
            stream.Close();

            hasLoaded = true;
        }
    }

    public void deleteSaveData()
    {
        string dataPath = Application.persistentDataPath;
        if (System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            File.Delete(dataPath + "/" + activeSave.saveName + ".save");
            Debug.Log("Deleted");
        }
    }

    public void deleteData()
    {

        if (SaveManager.instance != null)
        {

            for (int i = 0; i < SaveManager.instance.activeSave.correctlyIdentified.Length; i++)
            {
                SaveManager.instance.activeSave.correctlyIdentified[i] = false;
                SaveManager.instance.activeSave.proposedNames[i] = 99;
            }

            SaveManager.instance.activeSave.submissionOrder.Clear();
            SaveManager.instance.activeSave.round.Clear();
            Destroy(gameObject);
        }



    }
}

[System.Serializable]
public class saveData
{
    public string saveName;
    public bool[] correctlyIdentified;
    public List<int> submissionOrder;
    public int[] proposedNames;
    public List<int> round;
    public int roundCount;
    public bool click;
    
}