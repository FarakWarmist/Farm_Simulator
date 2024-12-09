using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Subtitles : MonoBehaviour
{
    [SerializeField] private TMP_Text _subtitlesText;
    [SerializeField] private Image _imageSubtitles;

    //Subtitle avec delai
    public void SetSubtitle(string subtitleText, int delay)
    {
        if (_imageSubtitles != null && _subtitlesText != null)
        {
            _imageSubtitles.gameObject.SetActive(true);
            _subtitlesText.text = subtitleText;
            StartCoroutine(RemoveSubtitle(delay));
        }
        else
        {
            Debug.LogError("_imageSubtitle or _subtitleText is null.");
        }
    }

    //Subtitle sans delai
    public void SetSubtitle(string subtitleText)
    {
        _imageSubtitles.gameObject.SetActive(true);
        _subtitlesText.text = subtitleText;
    }

    //Clear le subtitle
    private IEnumerator RemoveSubtitle(int delay)
    {
        yield return new WaitForSeconds(delay);
        _subtitlesText.text = string.Empty;
        _imageSubtitles.gameObject.SetActive(false);
    }
}
