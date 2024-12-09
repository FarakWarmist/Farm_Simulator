using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

[System.Serializable]
public class Product
{
    [SerializeField] private string _produitName;
    [SerializeField] private int _produitPrice;
    [SerializeField] private ProductType _produitSeller;
    [SerializeField] private int _quantity;

    public string ProduitName
    {
        get { return _produitName; }
        set { _produitName = value; }
    }

    public int ProduitPrice
    {
        get { return _produitPrice; }
        set 
        { 
            _produitPrice = Mathf.Max(0, value); 
        }
    }

    public ProductType ProduitSeller
    {
        get { return _produitSeller; }
        set { _produitSeller = value; }
    }

    public int Quantity
    {
        get { return _quantity; }
        set 
        { 
            _quantity = Mathf.Max(0,value); 
        }
    }

    public Product(string name, int price, ProductType produitSeller, int quantity)
    {
        ProduitName = name;
        ProduitPrice = price;
        ProduitSeller = produitSeller;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"Produit: {ProduitName}, Prix: {ProduitPrice}, Quantité: {Quantity}";
    }
}
