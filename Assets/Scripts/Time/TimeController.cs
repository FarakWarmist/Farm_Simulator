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
    private WeekDay _weekDay;

    private void Update()
    {
        UpdateTime();
        UpdateText();
    }

    private void UpdateTime()
    {
        GameManagerTime.Instance.CurrentTime += Time.deltaTime * _speedTime;

        if (GameManagerTime.Instance.CurrentTime > 86400f)
        {
            GameManagerTime.Instance.CurrentTime = 0;
            GameManagerTime.Instance.Day++;

            if (GameManagerTime.Instance.Day > 6)
            {
                GameManagerTime.Instance.Day = 0;
            }

            GameManagerTime.Instance.SaveData();
        }
    }

    private void UpdateText()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(GameManagerTime.Instance.CurrentTime);

        switch (GameManagerTime.Instance.Day)
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




                
        
    

