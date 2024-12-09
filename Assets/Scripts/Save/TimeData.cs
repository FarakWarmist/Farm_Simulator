using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

[System.Serializable]
public class TimeData
{
    [SerializeField] private float _currentTime;
    [SerializeField] private int _dayWeek;

    public float CurrentTime
    {
        get => _currentTime;
        set => _currentTime = Mathf.Clamp(value,0,86400f); //Pas d'heure negatif eet ne pas depasser 24h
    }

    public int DayWeek
    {
        get => _dayWeek;
        set => _dayWeek = Mathf.Clamp(value,0, 6); // Pas de jour négatif et ne pas depaser 6jours
    }

    public TimeData()
    {
        CurrentTime = 0;
        DayWeek = 0;
    }
}
