using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable //pour que tt les objets interactif ait une méthode Interact
{
    void Interact();
    string GetInteractionPrompt();
}

