using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractState : PlayerState //Script de l'etat d'interaction
{
    public override void EnterState(PlayerController player)
    {
        if (player.CurrentInteractable != null)
        {
            player.CurrentInteractable.Interact();
        }
        player.ResetStateAfterTeleport();
    }

    public override void UpdateState(PlayerController player)
    {
    }
}

