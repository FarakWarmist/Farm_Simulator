using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonFactory
{
    private Transform _parent;
    private Button _buttonPrefab;
    private ShopUIManager _shopUIManager;

    public ButtonFactory(Transform parent, Button prefab, ShopUIManager shopUIManager)
    {
        _parent = parent;
        _buttonPrefab = prefab;
        _shopUIManager = shopUIManager;
    }

    //Cree des Buttons
    public Button CreateButton(string text, UnityAction action)
    {
        Button button = Object.Instantiate(_buttonPrefab, _parent);
        button.transform.localPosition = _shopUIManager.UIPosition();
        button.GetComponentInChildren<TMP_Text>().text = text;
        button.onClick.AddListener(action);
        return button;
    }
}

