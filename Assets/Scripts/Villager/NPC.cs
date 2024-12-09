using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Villager
{
    public NPC(string villagerName, int startDay, int endDay)
        : base(villagerName, startDay, endDay)
    {
        // Initialisation des autre chose pour le NPC  ici
    }

    private void Start()
    {
        InitializeVillager();
        InitializeProduct();
    }

    private void InitializeVillager()
    {
        VillagerName = "Marie";
        StartDay = 8;
        EndDay = 17;
    }

    private void InitializeProduct()
    {
        _produitManager = new ProductManager();

        var oeuf = new Product("oeuf", 10, ProductType.NPC, 10);
        var lait = new Product("lait", 15, ProductType.NPC, 15);

        _produitManager.AddProduct(oeuf);
        _produitManager.AddProduct(lait);
    }

    public override void Interact()
    {
        if (_shop != null)
        {
            Debug.Log(2);
            //_shop.Shop(ProductType.NPC);
        }
        else
        {
            Debug.Log("Shop isnt initialized");
        }
    }

}
