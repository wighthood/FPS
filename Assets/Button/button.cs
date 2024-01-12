using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button: MonoBehaviour
{
    [SerializeField] GameObject hitEffect;
    public GameObject[] LinkedObjects;
    public float Basetimer;
    private Color color;
    private int i = 0;
    private bool activated = false;

    public void Button(Vector3 HitPos, Vector3 HitNormal)
    {

        Instantiate(hitEffect, HitPos, Quaternion.LookRotation(HitNormal));
        if (Basetimer <= 0)
        {
            invertstate();
        }
        else if (!activated)
        {
            activated = true;
            invertstate();
            StartCoroutine(_Timer());
        }
    }

    IEnumerator _Timer()
    {
        yield return new WaitForSeconds(Basetimer);
        invertstate();
        activated = false;
    }
    private void invertstate()
    {
        if (gameObject.GetComponent<Renderer>().material.color == new Color(0, 0.5f, 0))
        {
            color = new Color(0.5f, 0, 0);
        }
        else if (gameObject.GetComponent<Renderer>().material.color == new Color(0.5f, 0, 0))
        {
            color = new Color(0, 0.5f, 0);
        }

        gameObject.GetComponent<Renderer>().material.color = color;
        foreach (GameObject obj in LinkedObjects)
        {
            LinkedObjects[i].SetActive(!LinkedObjects[i].activeSelf);
            i++;
        }
        i = 0;
    }
}
