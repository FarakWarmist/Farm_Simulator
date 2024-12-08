using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Tool
{
    private void Awake()
    {
        ToolName = "Axe";
    }


    public override void Use(Vector2 targetPosition)
    {
        Debug.Log("action bucher du bois");
    }
}
