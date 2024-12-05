using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VendreProduit : Shop, IVendre
{
    public void Vendre()
    {
        ClearUI();

        //Savegarder la possition du button 
        _originalButtonPossition = _parentTransform.transform.localPosition;
        float x = _originalButtonPossition.x;
        y = 500;

        //Chercher tout les produit de pecher et leur quantiter
        var produits = Produit.ProduitPlayer
        .Where(produit => produit.Quantiter > 0)
        .Distinct();

        if (!produits.Any())
        {
            _subTitle.SetSubtitle("Vous avez aucun produit dans votre inventaire", 5);
            ClearUI();
            Time.timeScale = 1f;
            return;
        }

        foreach (var produit in produits)
        {
            Vector3 newPos = new Vector3(x, y, 0);

            //Initializer un button pour chaque produit
            Button produitUI = Instantiate(_buttonPrefab, _parentTransform.transform);
            produitUI.onClick.AddListener(() => ClickVendreProduit(produit, produitUI));
            produitUI.transform.localPosition = newPos;

            TMP_Text tMP_Text = produitUI.GetComponentInChildren<TMP_Text>();
            tMP_Text.text = produit.ToString();

            y -= 100;
        }

        Exit();
    }

    private void ClickVendreProduit(Produit item, Button button)
    {
        //GameManagerPlayerData.Instance.Gold += item.ProduitPrice;

        Produit playerItem = Produit.ProduitPlayer
         .FirstOrDefault(produit => produit.ProduitName == item.ProduitName);

        if (playerItem != null)
        {
            playerItem.Quantiter--;

            UpdateTextButton(item, button);

            if (playerItem.Quantiter == 0)
            {
                Produit.ProduitList.Remove(playerItem);
                Destroy(button.gameObject);
            }
        }

        Exit();
    }
}
