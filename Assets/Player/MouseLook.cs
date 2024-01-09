using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float sensitivityY = 0.5f;
    [SerializeField] Transform PlayerCamera;
    [SerializeField] float xclamp = 85f;
    float mousex, mousey;
    float xrotation = 0f;

    private void Update()
    {
        transform.Rotate(Vector3.up, mousex * Time.deltaTime);

        xrotation -= mousey;
        xrotation = Mathf.Clamp(xrotation, -xclamp, xclamp);
        Vector3 targetrotation = transform.eulerAngles;
        targetrotation.x = xrotation;
        PlayerCamera.eulerAngles = targetrotation;
    }
    public void ReceiveInput(Vector2 mouseInput)
    {
        mousex = mouseInput.x * sensitivityX;
        mousey = mouseInput.y * sensitivityY;
    }
}
