using System.Linq;
using UnityEngine.UI;

public class BuyProduct : GameShop, IBuy
{
    public void Buy(ProductType produitType)
    {
        _shopUIManager.ClearUI();
        _shopUIManager.ResetPosition();
        ShowGold();

        //Chercher tout les produit de leur ProduitType
        var produits = ProductManager.NpcProducts
        .Where(produit => produit.ProduitSeller == produitType && produit.Quantity > 0)
        .Distinct();

        if (!produits.Any()) //S'il ne trouve aucun produit
        {
            _subTitle.SetSubtitle("Aucun produit disponible à acheter", 3);
            return;
        }

        _subTitle.SetSubtitle("Quel produit voulez-veux acheter?");

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

    private void ClickBuyProduit(Product item, Button button, ProductType produitType)
    {
        //Check si le player a assez de Gold
        if (_playerData.Gold < item.ProduitPrice)
        {
            _subTitle.SetSubtitle("Vous avez pas assez d'argent pour acheter", 3);  
            return;
        }

        //Soustraire le gold du player avec le prix de l'item & diminuer la quantiter
        _playerData.Gold -= item.ProduitPrice;
        item.Quantity--;

        //Update le button Text
        _shopUIManager.UpdateButtonText(item, button);
        ShowGold();

        //Check si le produit n'est plus rendu a 0
        if (item.Quantity <= 0)
        {
            _produitManager.RemoveProduct(item);
            Destroy(button.gameObject);
            return;
        }

        //Chercher le produit dans l'inventaire du player
        Product playerItem = ProductManager.PlayerProducts
        .Where(produit => produit.ProduitName == item.ProduitName).
                             FirstOrDefault();

        if (playerItem != null)
        {
            playerItem.Quantity++;
        }
        else
        {
            var produit = new Product(item.ProduitName, item.ProduitPrice - 5, ProductType.Player, 1);
            _produitManager.AddProduct(produit);
        }

    }
}
