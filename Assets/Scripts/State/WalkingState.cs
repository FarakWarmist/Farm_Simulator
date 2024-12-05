using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : PlayerState
{
    public override void EnterState(PlayerController player)
    {
        Debug.Log("Player is walking.");
    }

    public override void UpdateState(PlayerController player)
    {
        Vector2 movement = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        player.Rigidbody.MovePosition(player.Rigidbody.position + movement * player.MoveSpeed * Time.deltaTime);

        if (movement == Vector2.zero)
        {
            player.SwitchState(player.IdleState);
        }
    }
}
