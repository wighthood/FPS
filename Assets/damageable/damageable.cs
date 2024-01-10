using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageable : MonoBehaviour
{
    [SerializeField]float maxhealth = 100;
    float currenthealth;

    private void Awake()
    {
        currenthealth = maxhealth;
    }

    public void takedamage(float damage)
    {
        currenthealth -= damage;
        if (currenthealth <= 0 ) 
        {
            die();
        }
    }

    void die()
    {
        print(name + "was destroyed");
        Destroy(gameObject);
    }
}
