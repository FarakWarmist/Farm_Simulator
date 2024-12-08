using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe : Tool
{
    private void Awake()
    {
        ToolName = "Pickaxe";
    }

    public override void Use(Vector2 targetPosition)
    {
        Debug.Log("Action miner");
    }
}
