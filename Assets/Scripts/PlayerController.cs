using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.Experimental.GraphView;
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
    public ToolSystem ToolSystem;
    private Vector2 direction = Vector2.zero;


    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        SwitchState(IdleState);
    }

    private void Update()
    {

        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        //Porte ou NPC
        if (Input.GetKeyDown(KeyCode.E) && CurrentInteractable is Door)
        {
            IsInteracting = true;
            SwitchState(InteractState); //On change d'etat si on interragit avec un object interactif
                                        //( vers l'etat d'interraction VS l'etat idle)
        }

        if (Input.GetKeyDown(KeyCode.F) && CurrentInteractable is NPC)
        {
            IsInteracting = true;
            SwitchState(InteractState);

        }


        //Outils
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            ToolSystem.EquipTool(FindObjectOfType<Axe>());
        
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ToolSystem.EquipTool(FindObjectOfType<Pickaxe>());

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ToolSystem.EquipTool(FindObjectOfType<FishingRod>());

        }

        //Use the tool
        if (Input.GetMouseButtonDown(0)) 
        {
            if (direction ==  Vector2.zero)
            {
                direction = Vector2.right;
            }
            ToolSystem.UseTool(transform.position, direction);
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
