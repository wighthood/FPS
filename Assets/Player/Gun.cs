using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Transform cam;

    [SerializeField] float range = 0.5f;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position,cam.forward, out hit, range))
        {
            if (hit.collider.GetComponent<button>() != null) 
            {
                hit.collider.GetComponent<button>().Button(hit.point, hit.normal);
            }
        }
    }
}
