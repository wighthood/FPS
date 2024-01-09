using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11f;
    [SerializeField] float gravity = -30f;
    [SerializeField] float jumpHeight = 3.5f;
    [SerializeField] LayerMask groundmask;
    Vector2 horizontalInput;
    Vector3 verticalVelocity = Vector3.zero;
    bool isgrounded;
    bool jump;

    private void Update()
    {
        isgrounded = Physics.CheckSphere(transform.position, 1.1f, groundmask);
        if (isgrounded )
        {
            verticalVelocity.y = 0;
        }
        Vector3 horizontalVelocity  = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y)*speed;
        controller.Move(horizontalVelocity*Time.deltaTime);
        if(jump)
        {
            if (isgrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            jump = false;
        }
        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity*Time.deltaTime);
    }
    public void receiveInput(Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
    }

    public void onJumpPressed()
    {
        jump = true;
    }
}
