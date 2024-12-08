using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public float MoveSpeed = 2f;
    private Vector2 movementInput;

    public PlayerState IdleState = new IdleState();
    public PlayerState WalkingState = new WalkingState();
    public PlayerState InteractState = new InteractState();
    public PlayerState CurrentState;

    public GameObject InteractionUI;
    public IInteractable CurrentInteractable;
    public bool IsInteracting;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        SwitchState(IdleState);
    }

    private void Update() //On change d'etat si on interragit avec un object interactif
        //( vers l'etat d'interraction VS l'etat idle)
    {

        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (Input.GetKeyDown(KeyCode.E) && CurrentInteractable is Door)
        {
            IsInteracting = true;
            SwitchState(InteractState);
        }
        else if (Input.GetKeyDown(KeyCode.F) && CurrentInteractable is NPC)
        {
            IsInteracting = true;
            SwitchState(InteractState);
        }

    }

    private void FixedUpdate()
    {
        Rigidbody.MovePosition(Rigidbody.position + movementInput * MoveSpeed * Time.fixedDeltaTime);
    }

    public void SwitchState(PlayerState newState)
    {
        CurrentState = newState;
        CurrentState.EnterState(this);
    }

    public void ResetStateAfterTeleport()
    {
        IsInteracting = false;
        SwitchState(IdleState);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            CurrentInteractable = interactable;
            if (InteractionUI != null)
            {
                InteractionUI.GetComponent<TMPro.TextMeshProUGUI>().text = interactable.GetInteractionPrompt();
                InteractionUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            if (CurrentInteractable == interactable)
            {
                CurrentInteractable = null;
                if (InteractionUI != null)
                {
                    InteractionUI.SetActive(false);
                }
            }
        }
    }
}
