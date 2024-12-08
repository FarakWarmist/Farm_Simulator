using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSystem : MonoBehaviour
{
    public Tool EquipedTool { get; private set; }


    public void EquipTool(Tool tool) 
    {
        EquipedTool = tool;
        Debug.Log($"Equipped tool: {tool.ToolName}");

    }

    public void UseTool(Vector2 playerPosition, Vector2 direction) 
    {
        if ( EquipedTool != null ) 
        {
            EquipedTool.Use(playerPosition + direction);
        }
        else 
        {
            Debug.LogWarning("No tool equiped bozo");
        }


    }






}
