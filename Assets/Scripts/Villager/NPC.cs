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
        VillagerName = "Marie";
        StartDay = 8;
        EndDay = 17;
        _produitManager = new ProduitManager();
        var oeuf = new Produit("oeuf",10,ProduitType.NPC, 10);
        var lait = new Produit("lait",15,ProduitType.NPC, 15);

        _produitManager.AddProduit(oeuf);
        _produitManager.AddProduit(lait);
    }

    public override void Interact()
    {
        if (_shop != null)
        {
            Debug.Log(2);
            _shop.Shop(ProduitType.NPC);
        }
        else
        {
            Debug.Log("Shop isnt initialized");
        }
    }

}
