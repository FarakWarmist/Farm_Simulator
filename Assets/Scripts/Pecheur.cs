using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pecheur : Villageois, IShopInteraction
{
    public Pecheur() //Initialization du pecheur
        : base("Marie", 100, 8, 17)
    {
        
    }

    public void AcheterProduit()
    {
        if (GameManagerTime.Instance.CurrentTime >= 8f && GameManagerTime.Instance.CurrentTime <= 17f)
        {
            //
        }
    }

    public void VendreProduit()
    {
        if (GameManagerTime.Instance.CurrentTime >= 8f && GameManagerTime.Instance.CurrentTime <= 17f)
        {
            //
        }
    }
}
