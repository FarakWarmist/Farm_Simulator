using System.Linq;
using UnityEngine.UI;

public class BuyProduct : GameShop, IBuy
{
    public void Buy(ProduitType produitType)
    {
        _shopUIManager.ClearUI();
        _shopUIManager.ResetPosition();
        ShowGold();

        //Chercher tout les produit de leur ProduitType
        var produits = ProduitManager.ProduitsNPC
        .Where(produit => produit.ProduitVendeur == produitType && produit.Quantiter > 0)
        .Distinct();

        if (!produits.Any()) //S'il ne trouve aucun produit
        {
            _subTitle.SetSubtitle("Aucun produit disponible à acheter", 3);
            CloseShop();
            return;
        }

        _subTitle.SetSubtitle("Quel Produit tu veux acheter");

        //Cree les buttons pour les produits du NPC
        foreach (var produit in produits)
        {
            Button button = null;
            button = _buttonFactory.CreateButton(produit.ToString(), () =>
                  ClickBuyProduit(produit, button, produitType)
                );

            _shopUIManager.DecreaseYPosition();
        }

        //Button Exit
        ExitButton();
    }

    private void ClickBuyProduit(Produit item, Button button, ProduitType produitType)
    {
        //Check si le player a assez de Gold
        if (_playerData.Gold < item.ProduitPrice)
        {
            _subTitle.SetSubtitle("Vous avez pas assez d'argent pour acheter", 3);
            CloseShop();
            return;
        }

        //Soustraire le gold du player avec le prix de l'item & diminuer la quantiter
        _playerData.Gold -= item.ProduitPrice;
        item.Quantiter--;

        //Update le button Text
        _shopUIManager.UpdateText(item, button);
        ShowGold();

        //Check si le produit n'est plus rendu a 0
        if (item.Quantiter <= 0)
        {
            _produitManager.RemoveItem(item);
            Destroy(button.gameObject);
            return;
        }

        //Chercher le produit dans l'inventaire du player
        Produit playerItem = ProduitManager.ProduitsPlayer
        .Where(produit => produit.ProduitName == item.ProduitName).
                             FirstOrDefault();

        if (playerItem != null)
        {
            playerItem.Quantiter++;
        }
        else
        {
            var produit = new Produit(item.ProduitName, item.ProduitPrice - 5, ProduitType.Player, 1);
            _produitManager.AddProduit(produit);
        }

    }
}
