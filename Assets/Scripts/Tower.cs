using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    private float fullHP = 1000f;
    private float currentHP;
    
    void Start()
    {
        currentHP = fullHP;
    }
    
    private void Die()
    {
        Debug.Log("is dead");
    }

    public void GetDamage(float hitForce)
    {
        if (currentHP > 0)
        {
            gameObject.GetComponent<HealthBarManager>().TakeDamage(hitForce);
        }
        else
        {
            currentHP = 0;
            Die();
        }
    }
}
