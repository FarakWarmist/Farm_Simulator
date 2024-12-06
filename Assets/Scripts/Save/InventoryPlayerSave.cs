using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class InventoryPlayerSave
{
    public List<Produit> ProduitList;

    public InventoryPlayerSave(List<Produit> produits)
    {
        this.ProduitList = produits;
    }
}
