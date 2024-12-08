using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : Tool
{
    private void Awake()
    {
        ToolName = "Fishing Rod";
    }

    public override void Use(Vector2 targetPosition)
    {
        Debug.Log("Lancer la ligne de peche");
    }
}
