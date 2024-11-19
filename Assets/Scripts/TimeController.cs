using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private float _speedTime = 10f;             // La vitesse que le temps avance dans le jeu 
    [SerializeField] private TMP_Text _timeText;
    private string[] _weeksDay = { "Dimanche", "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi" };

    private void Update()
    {
        UpdateTime();
        UpdateText();
    }

    private void UpdateTime()
    {
        GameManagerTime.Instance.CurrentTime += Time.deltaTime * _speedTime;

        if (GameManagerTime.Instance.CurrentTime > 24f)
        {
            GameManagerTime.Instance.Day++;

            if (GameManagerTime.Instance.Day > 6)
            {
                GameManagerTime.Instance.Day = 0;
            }
        }
    }

    private void UpdateText()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(GameManagerTime.Instance.CurrentTime);
        _timeText.text = $"{_weeksDay[GameManagerTime.Instance.Day]}: {timeSpan.Hours}H {timeSpan.Minutes}Min {timeSpan.Seconds}Sec";
    }
}
