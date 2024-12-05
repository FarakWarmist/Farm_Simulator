using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Villageois : MonoBehaviour //IInteractable
{
    protected string _villageoisName { get; set; }
    protected int _startWorking { get; set; }         // Le temps que le villageois commence (sa journee)
    protected int _endWorking { get; set; }          // Le temps que le villagois fini (sa journee)

    [SerializeField] protected SubTitle _subtitle;
    [SerializeField] protected Shop _shop;
    protected Produit _villageoisProduit;

    protected virtual void Awake()
    {
        _villageoisName = "DefaultName";
        _startWorking = 0;
        _endWorking = 0;
        _villageoisProduit = new Produit("NomParDefaut", 0, ProduitType.None, 0);
    }

    //public abstract void Interatable();
}
