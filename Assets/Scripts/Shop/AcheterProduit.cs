using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AcheterProduit : Shop, IAcheter
{
    public void Acheter(ProduitType produitType)
    {
        ClearUI();

        //Savegarder la possition du button 
        _originalButtonPossition = _parentTransform.transform.localPosition;
        float x = _originalButtonPossition.x;
        y = 500;

        //Chercher tout les produit de leur ProduitType
        var produits = Produit.ProduitList
        .Where(produit => produit.ProduitVendeur == produitType && produit.Quantiter > 0)
        .Distinct();

        if (!produits.Any())
        {
            _subTitle.SetSubtitle("Aucun produit disponible à acheter.", 5);
            Time.timeScale = 1f;
            return;
        }

        foreach (var produit in produits)
        {
            Vector3 newPos = new Vector3(x, y, 0);

            //Initializer un button pour chaque produit
            Button produitUI = Instantiate(_buttonPrefab, _parentTransform.transform);
            produitUI.onClick.AddListener(() => ClickAcheterProduit(produit, produitUI, produitType));
            produitUI.transform.localPosition = newPos;

            TMP_Text tMP_Text = produitUI.GetComponentInChildren<TMP_Text>();
            tMP_Text.text = produit.ToString();

            y -= 100;
        }

        Exit();
    }

    private void ClickAcheterProduit(Produit item, Button button, ProduitType produitType)
    {
        //if (GameManagerPlayerData.Instance.Gold < item.ProduitPrice)
        //{
        //    _subTitle.SetSubtitle($"Vous avez pas assez d'argent pour acheter {item.ProduitName}", 5);
        //    ClearUI();
        //    Time.timeScale = 1f;
        //    return;
        //}

        //GameManagerPlayerData.Instance.Gold -= item.ProduitPrice;

        Produit quantity = Produit.ProduitList
            .Where(p => p.ProduitName == item.ProduitName && p.ProduitVendeur == item.ProduitVendeur)
            .FirstOrDefault();

        quantity.Quantiter--;

        UpdateTextButton(item, button);

        if (item.Quantiter <= 0)
        {
            Produit.ProduitList.Remove(quantity);
            Destroy(button.gameObject);
            return;
        }

        Produit playerItem = Produit.ProduitPlayer
        .Where(produit => produit.ProduitName == item.ProduitName).
                             FirstOrDefault();

        if (playerItem != null)
        {
            playerItem.Quantiter++;
        }
        else
        {
            Produit.ProduitPlayer.Add(new Produit(item.ProduitName, item.ProduitPrice - 20, ProduitType.Player, 1));
        }

        Exit();
    }
}
