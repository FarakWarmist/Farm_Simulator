using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManagerTime : MonoBehaviour, ISave
{
    public static GameManagerTime Instance { get; private set; }
    public TimeData TimeData { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    public void SaveData() // Sauvegarder le Temps et le jour 
    {
        string json = JsonUtility.ToJson(TimeData, true);
        string file_path = Path.Combine(Application.persistentDataPath, "Time.json");
        File.WriteAllText(file_path, json);
        Debug.Log($"Data loaded: CurrentTime:{TimeData.CurrentTime}, {TimeData.DayWeek}");
    }

    public void LoadData() // Loader le Temps et le jour 
    {
        string file_path = Path.Combine(Application.persistentDataPath, "Time.json");

        if (File.Exists(file_path))
        {
            string json = File.ReadAllText(file_path);
            TimeData = JsonUtility.FromJson<TimeData>(json);
            Debug.Log($"Data loaded: CurrentTime={TimeData.CurrentTime},  {TimeData.DayWeek}");
        }
        else
        {
            TimeData = new TimeData();
            Debug.Log($"Data loaded: CurrentTime={TimeData.CurrentTime},  {TimeData.DayWeek}");
        }
    }

    public void DeleteData() // Supprimer le Temps et le jour 
    {
        string file_path = Path.Combine(Application.persistentDataPath, "Time.json");

        if (File.Exists(file_path))
        {
            File.Delete(file_path);
            TimeData = new TimeData();
        }
    }
}

