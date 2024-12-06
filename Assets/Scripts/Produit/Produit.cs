using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Produit
{
    [SerializeField] private string _produitName;
    [SerializeField] private int _produitPrice;
    [SerializeField] private ProduitType _produitVendeur;
    [SerializeField] private int _quantiter;

    public string ProduitName
    {
        get { return _produitName; }
        set { _produitName = value; }
    }

    public int ProduitPrice
    {
        get { return _produitPrice; }
        set { _produitPrice = value; }
    }

    public ProduitType ProduitVendeur
    {
        get { return _produitVendeur; }
        set { _produitVendeur = value; }
    }

    public int Quantiter
    {
        get { return _quantiter; }
        set { _quantiter = value; }
    }

    public Produit(string name, int price, ProduitType produitVendeur, int quantiter)
    {
        ProduitName = name;
        ProduitPrice = price;
        ProduitVendeur = produitVendeur;
        Quantiter = quantiter;
    }

    public override string ToString()
    {
        return $"Produit: {ProduitName}, Prix: {ProduitPrice}, Quantité: {Quantiter}";
    }
}
