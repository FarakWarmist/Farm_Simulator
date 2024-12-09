using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public abstract class Villager : MonoBehaviour, IInteractable
{
    [SerializeField] protected GameShop _shop;
    protected ProductManager _produitManager;

    private string _villagerName;
    protected string VillagerName 
    {
        get => _villagerName;
        set => _villagerName = value;
    }

    private int _startDay;   // L'heure que le villageois commence sa journée
    protected int StartDay       
    {
        get => _startDay;
        set => _startDay = Mathf.Clamp(value, 0, 24);
    }

    private int _endDay; // L'heure que le villagois fini sa journée
    protected int EndDay           
    {
        get => _endDay;
        set => _endDay = Mathf.Clamp(value, _startDay + 1, 24);
    }

    public Villager(string villagerName, int startDay, int endDay)
    {
        VillagerName = villagerName;
        StartDay= startDay * 3600;
        EndDay= endDay * 3600;
    }

    public string GetInteractionPrompt()
    {
        return "Press F to talk";
    }

    public abstract void Interact();
}
    

