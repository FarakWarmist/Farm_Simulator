using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float _speedTime = 10f;  // La vitesse que le temps avance dans le jeu 
    [SerializeField] private TMP_Text _timeText;
    private TimeData _timeData;
    private WeekDay _weekDay;

    public void Start()
    {
        _timeData = GameManagerTime.Instance.TimeData;
    }

    private void Update()
    {
        UpdateTime();
        UpdateText();
    }

    private void UpdateTime()
    {
        _timeData.CurrentTime += Time.deltaTime * _speedTime;

        if (_timeData.CurrentTime > 86400f)
        {
            _timeData.CurrentTime = 0;
            _timeData.Day++;

            if (_timeData.Day > 6)
            {
                _timeData.Day = 0;
            }

            GameManagerTime.Instance.SaveData();
        }
    }

    private void UpdateText()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(_timeData.CurrentTime);

        switch (_timeData.Day)
        {
            case 0:
                _weekDay = WeekDay.Dimanche;
                break;
            case 1:
                _weekDay = WeekDay.Lundi;
                break;
            case 2:
                _weekDay = WeekDay.Mardi;
                break;
            case 3:
                _weekDay = WeekDay.Mercredi;
                break;
            case 4:
                _weekDay = WeekDay.Jeudi;
                break;
            case 5:
                _weekDay = WeekDay.Vendredi;
                break;
            case 6:
                _weekDay = WeekDay.Samedi;
                break;
        }

        _timeText.text = $"{_weekDay}: {timeSpan.Hours}H {timeSpan.Minutes:00}Min {timeSpan.Seconds:00}Sec";
    }
}