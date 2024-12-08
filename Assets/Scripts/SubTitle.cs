using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubTitle : MonoBehaviour
{
    [SerializeField] private TMP_Text _subtitleText;
    [SerializeField] private Image _imageSubtitle;

    public void SetSubtitle(string subtitleText, int delay)
    {
        if (_imageSubtitle != null && _subtitleText != null)
        {
            _imageSubtitle.gameObject.SetActive(true);
            _subtitleText.text = subtitleText;
            StartCoroutine(RemoveSubtitle(delay));
        }
        else
        {
            Debug.LogError("_imageSubtitle or _subtitleText is null.");
        }
    }

    public void SetSubtitle(string subtitleText)
    {
        _imageSubtitle.gameObject.SetActive(true);
        _subtitleText.text = subtitleText;
    }

    private IEnumerator RemoveSubtitle(int delay)
    {
        yield return new WaitForSeconds(delay);
        _subtitleText.text = string.Empty;
        _imageSubtitle.gameObject.SetActive(false);
    }
}
