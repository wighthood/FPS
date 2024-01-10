using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;
    [SerializeField] Gun gun;
    PlayerController controls;
    PlayerController.PlayerControlActions playerMovement;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    private void Awake()
    {
        controls = new PlayerController();
        playerMovement = controls.PlayerControl;
        playerMovement.PlayerMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        playerMovement.Jump.performed += _ => movement.onJumpPressed();
        playerMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        playerMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        playerMovement.Shoot.performed += _ => gun.Shoot();
    }

    private void Update()
    {
        movement.receiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);
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
