using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProduitPlayerListSave
{
    public List<Produit> ProduitList;

    public ProduitPlayerListSave(List<Produit> produits)
    {
        this.ProduitList = produits;
    }
}
