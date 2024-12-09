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
        var produits = ProductManager.PlayerProducts
        .Where(produit => produit.Quantity > 0)
        .Distinct();

        if (!produits.Any())
        {
            _subTitle.SetSubtitle("Vous avez aucun produit dans votre inventaire", 3);
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

    private void ClickSellProduit(Product item, Button button)
    {
        _playerData.Gold += item.ProduitPrice;

        item.Quantity--;

        _shopUIManager.UpdateButtonText(item, button);
        ShowGold();

        if (item.Quantity == 0)
        {
            ProductManager.PlayerProducts.Remove(item);
            Destroy(button.gameObject);
        }
    }
}
