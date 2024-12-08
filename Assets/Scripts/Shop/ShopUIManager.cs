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
    private float xPosition;
    private float yPosition = 300.0f;

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
        xPosition = position.x;
        position.y = yPosition;
        return position;
    }

    //Pour Updater l'affichage des produits 
    public void UpdateText(Produit item, Button button)
    {
        TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
        button.GetComponentInChildren<TMP_Text>().text = item.ToString();
    }

    //Pour diminuer la position Y
    public void DecreaseYPosition()
    {
        yPosition -= _ySpacing;

        Vector3 position = _parentTransform.localPosition;
        position.y = yPosition;
        _parentTransform.localPosition = position;
    }

    //Reset la position
    public void ResetPosition()
    {
        yPosition = 300.0f;
        Vector3 position = _parentTransform.localPosition;
        xPosition = position.x;
        position.y = yPosition;
        _parentTransform.localPosition = position;
    }
}
