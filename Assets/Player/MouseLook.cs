using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{

    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float sensitivityY = 0.5f;
    [SerializeField] Transform PlayerCamera;
    [SerializeField] float xclamp = 85f;
    float mousex, mousey;
    float xrotation = 0f;
    private bool MouseLock = true;

    private void Update()
    {
        if (MouseLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            transform.Rotate(Vector3.up, mousex * Time.deltaTime);
            xrotation -= mousey;
            xrotation = Mathf.Clamp(xrotation, -xclamp, xclamp);
            Vector3 targetrotation = transform.eulerAngles;
            targetrotation.x = xrotation;
            PlayerCamera.eulerAngles = targetrotation;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }

    public void ReceiveInput(Vector2 mouseInput)
    {
        mousex = mouseInput.x * sensitivityX;
        mousey = mouseInput.y * sensitivityY;
    }

    public void LockMouse(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            MouseLock = !MouseLock;
        }
    }
}
