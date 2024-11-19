using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Villageois
{
    [SerializeField] protected Canvas _canvasButton; // Le Canvas ou les options (Acheter et Vendre) vont apparaitre
    private string _villageoisName {get; set;}
    private int _villageoisGold { get; set;}
    private int _startWorking { get; set; }         // Le temps que le villageois commence (sa journee)
    private int _endWorking { get; set; }           // Le temps que le villagois fini (sa journee)

    protected string _villageoisDialogue; 
    
    //S'il y a pas de methode pour les dialoges on peux utilise ca
    //protected TMP_Text _textDialogue;

    protected Villageois(string villageoisName, int villageoisGold, int startWorking, int endWorking)
    {
        _villageoisName = villageoisName;
        _villageoisGold = villageoisGold;
        _startWorking = startWorking;
        _endWorking = endWorking;
    }
}
