using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManagerTime : MonoBehaviour, ISave
{
    public static GameManagerTime Instance { get; private set; }
    [SerializeField] private float _currentTime;
    [SerializeField] private int _day;

    public float CurrentTime
    {
        get { return _currentTime; }
        set { _currentTime = value; }
    }

    public int Day
    {
        get { return _day; }
        set { _day = value; }
    }

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

    public void SaveData()
    {
        string json = JsonUtility.ToJson(this, true);
        string file_path = Path.Combine(Application.persistentDataPath, "Time.json");
        File.WriteAllText(file_path, json);
        Debug.Log($"Data loaded: CurrentTime={_currentTime}, Day={_day}");
    }

    public void LoadData()
    {
        string file_path = Path.Combine(Application.persistentDataPath, "Time.json");

        if (File.Exists(file_path))
        {
            Debug.Log($"Loading");
            string json = File.ReadAllText(file_path);
            JsonUtility.FromJsonOverwrite(json, this);
            Debug.Log($"Data loaded: CurrentTime={_currentTime}, Day={_day}");
        }
        else
        {
            Debug.Log("No saved data found");
        }
    }

    public void DeleteData()
    {
        string file_path = Path.Combine(Application.persistentDataPath, "Time.json");

        if (File.Exists(file_path))
        {
            File.Delete(file_path);
        }
    }
}
