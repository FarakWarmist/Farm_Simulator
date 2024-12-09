using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class InventoryPlayerData
{
    [SerializeField] private List<Product> _produitList;
    
    public List<Product> ProduitList { get { return _produitList; } set { _produitList = value; } }

    public InventoryPlayerData(List<Product> product)
    {
        ProduitList = product;
    }
}
