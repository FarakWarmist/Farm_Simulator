using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager
{
    private Transform _parentTransform;
    private float _ySpacing = 100;
    private float _yDefaultPosition = 300f;
    private float _currentYPosition;

    public ShopUIManager(Transform transform) 
    {
        _parentTransform = transform;
    }

    //Pour supprimer ce qu'il ya dans le parent (les Buttons)
    public void ClearUI()
    {
        if (_parentTransform.childCount > 0)
        {
            foreach (Transform child in _parentTransform)
            {
                Object.Destroy(child.gameObject);
            }
        }
    }

    // Obtenir la position
    public Vector3 UIPosition()
    {
        Vector3 position = _parentTransform.localPosition;
        position.y = _currentYPosition;
        return position;
    }

    //Pour Updater l'affichage des produits 
    public void UpdateButtonText(Product item, Button button)
    {
        TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
        button.GetComponentInChildren<TMP_Text>().text = item.ToString();
    }

    //Pour diminuer la position Y
    public void DecreaseYPosition()
    {
        _currentYPosition -= _ySpacing;

        Vector3 position = _parentTransform.localPosition;
        position.y = _currentYPosition;
        _parentTransform.localPosition = position;
    }

    //Reset la position
    public void ResetPosition()
    {
        _currentYPosition = _yDefaultPosition;
        Vector3 position = _parentTransform.localPosition;
        position.y = _currentYPosition;
        _parentTransform.localPosition = position;
    }
}
