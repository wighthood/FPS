using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button: MonoBehaviour
{
    [SerializeField] GameObject hitEffect;
    public GameObject[] LinkedObjects;
    private Color color;
    private int i = 0;

    public void Button(Vector3 HitPos, Vector3 HitNormal)
    {
        if (gameObject.GetComponent<Renderer>().material.color == new Color(0,0.5f,0))
        {
            color = new Color(0.5f, 0, 0);
        }
        else if (gameObject.GetComponent<Renderer>().material.color == new Color(0.5f, 0, 0))
        {
            color = new Color(0, 0.5f, 0);
        }

        gameObject.GetComponent<Renderer>().material.color = color;
        Instantiate(hitEffect, HitPos, Quaternion.LookRotation(HitNormal));
        foreach(GameObject obj in LinkedObjects) 
        {
            if (LinkedObjects[i].activeSelf == false)
            {
                LinkedObjects[i].SetActive(true);
            }
            else if (LinkedObjects[i].activeSelf == true)
            {
                LinkedObjects[i].SetActive(false);
            }
            i++;
        }
        i = 0;
        
    }

}
