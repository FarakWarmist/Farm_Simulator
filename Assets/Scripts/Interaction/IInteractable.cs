using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable //pour que tt les objets interactif ait une m�thode Interact
{
    void Interact();
    string GetInteractionPrompt();
}

