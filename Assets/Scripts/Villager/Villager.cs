using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public abstract class Villager : MonoBehaviour, IInteractable
{
    [SerializeField] protected GameShop _shop;

    protected string DialogueVillager { get; set; }

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
        set
        {
            if (value > 0)
            {
                _startDay = value;
            }
            else
            {
                _startDay = 0;
            }
        }
    }

    private int _endDay; // L'heure que le villagois fini sa journée
    protected int EndDay           
    {
        get => _endDay;

        set
        {
            if (value > _startDay)
            {
                _endDay = value;
            }
            else
            {
                _endDay = _startDay + 1;
            }
        }
    }

    public Villager(string villagerName, int startDay, int endDay)
    {
        VillagerName = villagerName;
        StartDay= startDay * 3600;
        EndDay= endDay * 3600;
    }

    public abstract void Interact();
}
    

