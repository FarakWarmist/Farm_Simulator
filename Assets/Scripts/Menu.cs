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
    [SerializeField] private GameObject _inventory;
    [SerializeField] private TMP_Text _inventoryText;
    [SerializeField] private Button _buttonInventory;
    [SerializeField] private Button _buttonExit;

    private bool _isMenuActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isMenuActive = !_isMenuActive;

            if (_isMenuActive)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
        }
    }

    //Ouvrire le menu 
    private void OpenMenu()
    {
        _menu.SetActive(true);
        _inventory.SetActive(false);
        _canvas.enabled = false;
        Time.timeScale = 0;

        _buttonInventory.onClick.AddListener(() => ShowInventory());
        _buttonExit.onClick.AddListener(() => ExitGame());
    }

    //Fermer le menu
    private void CloseMenu()
    {
        _menu.SetActive(false);
        _inventory.SetActive(false);
        _canvas.enabled = true;
        Time.timeScale = 1;

        _buttonInventory.onClick.RemoveAllListeners();
        _buttonExit.onClick.RemoveAllListeners();
    }

    private void ShowInventory()
    {
        _inventory.SetActive(true);
        _menu.SetActive(false);

        if (ProductManager.PlayerProducts == null || ProductManager.PlayerProducts.Count == 0)
        {
            _inventoryText.text = "Aucun produit dans votre inventaire";
            return;
        }

        _inventoryText.text = "";

        foreach (var items in ProductManager.PlayerProducts)
        {
            _inventoryText.text += $"Nom: {items.ProduitName} Quantiter: {items.Quantity}\n";
        }
    }

    private void ExitGame()
    {
        GameManagerTime.Instance.SaveData();
        GameManagerPlayerData.Instance.SaveData();
    }
}
