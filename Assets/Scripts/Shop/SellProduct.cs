using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellProduct : GameShop, ISell
{
    public void Sell()
    {
        _shopUIManager.ClearUI();
        _shopUIManager.ResetPosition();
        ShowGold();

        //Chercher tout les produit du Player et leur quantiter
        var produits = ProduitManager.ProduitsPlayer
        .Where(produit => produit.Quantiter > 0)
        .Distinct();

        if (!produits.Any())
        {
            _subTitle.SetSubtitle("Vous avez aucun produit dans votre inventaire", 3);
            CloseShop();
            return;
        }

        _subTitle.SetSubtitle("Quel produit tu veux me vendre");
        foreach (var produit in produits)
        {
            Button button = null;
            button = _buttonFactory.CreateButton(produit.ToString(), () =>
                  ClickSellProduit(produit, button)
                );

            _shopUIManager.DecreaseYPosition();
        }

        ExitButton();
    }

    private void ClickSellProduit(Produit item, Button button)
    {
        _playerData.Gold += item.ProduitPrice;

        item.Quantiter--;

        _shopUIManager.UpdateText(item, button);
        ShowGold();

        if (item.Quantiter == 0)
        {
            ProduitManager.ProduitsPlayer.Remove(item);
            Destroy(button.gameObject);
        }
    }
}
