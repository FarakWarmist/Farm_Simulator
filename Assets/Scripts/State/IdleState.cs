using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    public override void EnterState(PlayerController player)
    {
        Debug.Log("Player is idle.");
    }

    public override void UpdateState(PlayerController player)
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            player.SwitchState(player.WalkingState);
        }
    }
}
