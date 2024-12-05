using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.Progress;


public class Pecheur : Villageois
{
    protected override void Awake()
    {
        base.Awake();
        _villageoisName = "Marie";
        _startWorking = 8 * 3600;
        _endWorking = 17 * 3600;
        _villageoisProduit.AddProduit("test", 1, ProduitType.Pecheur, 10);
    }

    //public override void Interatable()
    //{
    //    _shop.ShowOption(ProduitType.Pecheur);
    //}
}
