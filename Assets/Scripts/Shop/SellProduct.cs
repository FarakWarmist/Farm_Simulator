//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public class SellProduct : GameShop, ISell
//{
//    public void Vendre()
//    {
//        ClearUI();

//        //Savegarder la possition du button 
//        _originalButtonPossition = _parentTransform.transform.localPosition;
//        float xPosition = _originalButtonPossition.x;
//        yPosition = 500;

//        //Chercher tout les produit du Player et leur quantiter
//        var produits = ProduitManager.
//        .Where(produit => produit.Quantiter > 0)
//        .Distinct();

//        if (!produits.Any())
//        {
//            QuitShopState("Vous avez aucun produit dans votre inventaire");
//        }

//        foreach (var produit in produits)
//        {
//            Button button = CreateButton(new Vector3(xPosition, yPosition,0), produit.ToString(), null);

//            button.onClick.AddListener(() =>
//            {
//                ClickVendreProduit(produit, button);
//            }
//            );
//        }

//        ExitShop();
//    }

//    private void ClickVendreProduit(Produit item, Button button)
//    {
//        GameManagerPlayerData.Instance.Gold += item.ProduitPrice;

//        if (item != null)
//        {
//            item.Quantiter--;

//            UpdateTextButton(item, button);

//            if (item.Quantiter == 0)
//            {
//                Produit.ProduitList.Remove(item);
//                Destroy(button.gameObject);
//            }
//        }
//    }
//}
