using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public string ToolName; //Hache, pioche, canne a peche (? thats it right?)

    public abstract void Use(Vector2 targetPosition);
}
