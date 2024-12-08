using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable //Script pour quand on interagit avec une porte (ou any gameobject
    // pour se TP a une autre zone)
{
    public Transform TargetLocation;

    public void Interact()
    {
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                player.transform.position = TargetLocation.position;

                Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Vector2.zero;
                }
            }
        }
    }

    public string GetInteractionPrompt()
    {
        return "Press E to interact";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    }
}
