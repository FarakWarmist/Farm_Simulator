using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

[System.Serializable]
public class TimeData
{
    [SerializeField] private float _currentTime;
    [SerializeField] private int _day;

    public float CurrentTime
    {
        get => _currentTime;
        set => _currentTime = Mathf.Max(0,value); //Pas d'heure negatif
    }

    public int Day
    {
        get => _day;
        set => _day = Mathf.Max(0, value); // Pas de jour négatif
    }

    public TimeData()
    {
        _currentTime = 0;
        _day = 0;
    }
}
