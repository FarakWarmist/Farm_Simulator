using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _inventaire;
    [SerializeField] private TMP_Text _inventaireText;
    [SerializeField] private Button _buttonInventaire;
    [SerializeField] private Button _exit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_menu.activeInHierarchy || _inventaire.activeInHierarchy)
            {
                _menu.SetActive(false);
                _inventaire.SetActive(false);
                _canvas.enabled = true;
                Time.timeScale = 1;
                _buttonInventaire.onClick.RemoveAllListeners();
                _exit.onClick.RemoveAllListeners();

            }
            else
            {
                _menu.SetActive(true);
                _canvas.enabled = false;
                Time.timeScale = 0;
                _buttonInventaire.onClick.AddListener(() => ButonInventaire());
                _exit.onClick.AddListener(() => ExitGame());

            }
        }
    }

    private void ExitGame()
    {
        GameManagerTime.Instance.SaveData();
        //GameManagerPlayerData.Instance.SaveData();
    }

    private void ButonInventaire()
    {
        _inventaire.SetActive(true);
        _menu.SetActive(false);

        foreach (var player in Produit.ProduitPlayer)
        {
            _inventaireText.text = $"Nom: {player.ProduitName} Quantiter: {player.Quantiter}\n";
        }

        if (Produit.ProduitPlayer == null || Produit.ProduitPlayer.Count == 0)
        {
            _inventaireText.text = string.Empty;
        }
    }
}
