using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public abstract void EnterState(PlayerController player);
    public abstract void UpdateState(PlayerController player);
}
