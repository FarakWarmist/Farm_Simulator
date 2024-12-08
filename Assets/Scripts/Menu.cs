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
                _buttonInventaire.onClick.AddListener(() => ButtonInventaire());
                _exit.onClick.AddListener(() => ExitGame());

            }
        }
    }

    private void ExitGame()
    {
        GameManagerTime.Instance.SaveData();
        GameManagerPlayerData.Instance.SaveData();
    }

    private void ButtonInventaire()
    {
        _inventaire.SetActive(true);
        _menu.SetActive(false);

        if (ProduitManager.ProduitsPlayer == null || ProduitManager.ProduitsPlayer.Count == 0)
        {
            _inventaireText.text = "aucun produit dans votre inventaire";
            return;
        }

        _inventaireText.text = "";

        foreach (var items in ProduitManager.ProduitsPlayer)
        {
            _inventaireText.text += $"Nom: {items.ProduitName} Quantiter: {items.Quantiter}\n";
        }
    }
}
