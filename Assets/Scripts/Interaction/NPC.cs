using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public string DialogueText = ""; 
    //le dialogue du npc irait ici :)

    public void Interact()
    {
        Debug.Log($"le npc a dit: {DialogueText}");
        //les autres actions du npc, vendre des objects etc seraient a rajouter ici
        //exemple ouvrir un menu de shop (quand on interagit avec)

    }
}
