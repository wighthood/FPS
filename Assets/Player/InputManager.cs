using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] Movement movement;
    PlayerController controls;
    PlayerController.PlayerControlActions playerMovement;

    Vector2 horizontalInput;

    private void Awake()
    {
        controls = new PlayerController();
        playerMovement = controls.PlayerControl;
        playerMovement.PlayerMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        playerMovement.Jump.performed += _ => movement.onJumpPressed();
    }

    private void Update()
    {
        movement.receiveInput(horizontalInput);
    }
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


}
