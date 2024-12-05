using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubTitle : MonoBehaviour
{
    public static SubTitle Instance {get; private set;}
    [SerializeField] private TMP_Text _subtitleText;
    [SerializeField] private GameObject _subtitle;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            gameObject.SetActive(false);
        }
    }

    public void SetSubtitle(string subtitleText, int delay)
    {
        _subtitle.SetActive(true);
        _subtitleText.text = subtitleText;
        StartCoroutine(RemoveSubtitle(delay));
    }

    private IEnumerator RemoveSubtitle(int delay)
    {
        yield return new WaitForSeconds(delay);
        _subtitleText.text = string.Empty;
        _subtitle.SetActive(false);
    }
}
