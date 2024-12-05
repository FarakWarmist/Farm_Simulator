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

    private static List<Produit> _produitList = new List<Produit>();
    private static List<Produit> _produitPlayer = new List<Produit>();

    private void Awake()
    {
        _produitList.Clear();
        _produitPlayer.Clear();
    }

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

    public static List<Produit> ProduitList
    {
        get { return _produitList; }
        set { _produitList = value; }
    }

    public static List<Produit> ProduitPlayer
    {
        get { return _produitPlayer; }
        set { _produitPlayer = value; }
    }

    public Produit() { }

    public Produit(string name, int price, ProduitType produitVendeur, int quantiter)
    {
        ProduitName = name;
        ProduitPrice = price;
        ProduitVendeur = produitVendeur;
        Quantiter = quantiter;

        if (produitVendeur == ProduitType.Player)
        {
            _produitPlayer.Add(this);
        }
        else
        {
            _produitList.Add(this);
        }
    }

    public override string ToString()
    {
        return $"Produit: {ProduitName}, Prix: {ProduitPrice}, Quantité: {Quantiter}";
    }

    public void AddProduit(string name, int price, ProduitType produitVendeur, int quantity)
    {
        Produit newProduit = new Produit(name, price, produitVendeur, quantity);

        if (newProduit.ProduitVendeur == ProduitType.Player)
        {
            _produitPlayer.Add(newProduit);
        }
        else
        {
            _produitList.Add(newProduit);
        }
    }
}
