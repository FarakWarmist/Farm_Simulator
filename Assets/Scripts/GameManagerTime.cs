using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class GameManagerTime : MonoBehaviour, ISave
{
    public static GameManagerTime Instance {get ; set;}
    public float CurrentTime;
    public int Day;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadData()
    {
        string file_path = Path.Combine(Application.persistentDataPath, "Time.json");

        if (File.Exists(file_path))
        {
            string json = File.ReadAllText(file_path);
            JsonUtility.FromJsonOverwrite(json, this);
            Debug.Log("Data loaded successfully.");
        }
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(this, true);
        string file_path = Path.Combine(Application.persistentDataPath, "Time.json");
        File.WriteAllText(file_path, json);
        Debug.Log("Data saved successfully.");
    }
}
