//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public class BuyProduct : GameShop, IBuy
//{
//    public void Buy(ProduitType produitType)
//    {
//        ClearUI();

//        //Savegarder la possition du button 
//        _originalButtonPossition = _parentTransform.transform.localPosition;
//        float xPosition = _originalButtonPossition.x;
//        yPosition = 500f;

//        //Chercher tout les produit de leur ProduitType
//        //var produits = Produit.ProduitList
//        .Where(produit => produit.ProduitVendeur == produitType && produit.Quantiter > 0)
//        .Distinct();

//        if (!produits.Any()) //S'il ne trouve aucun produit
//        {
//            SubTitle.Instance.SetSubtitle("Aucun produit disponible à acheter.", 3);
//            Time.timeScale = 1f;
//            ClearUI();
//            return;
//        }

//        //Cree les button pour les produits du NPC
//        foreach (var produit in produits)
//        {
//            Button button = null;
//            button = CreateButton(new Vector3(xPosition, yPosition, 0), produit.ToString(), () =>
//                  ClickAcheterProduit(produit, button, produitType)

//                );
//            yPosition -= 100; 
//        }

//        ExitShop();
//    }
     
//    private void ClickAcheterProduit(Produit item, Button button, ProduitType produitType)
//    {
//        if (GameManagerPlayerData.Instance.Gold < item.ProduitPrice)
//        {
//            QuitShopState("Vous avez pas assez d'argent pour acheter");
//        }

//        GameManagerPlayerData.Instance.Gold -= item.ProduitPrice;

//        item.Quantiter--;

//        UpdateTextButton(item, button);

//        if (item.Quantiter <= 0)
//        {
//            Produit.ProduitList.Remove(item);
//            Destroy(button.gameObject);
//            return;
//        }

//        Produit playerItem = Produit.ProduitPlayer
//        .Where(produit => produit.ProduitName == item.ProduitName).
//                             FirstOrDefault();

//        if (playerItem != null)
//        {
//            playerItem.Quantiter++;
//        }
//        else
//        {
//            Produit.ProduitPlayer.Add(new Produit(item.ProduitName, item.ProduitPrice - 10, ProduitType.Player, 1));
//        }
//    }
//}
