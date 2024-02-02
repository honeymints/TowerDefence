using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] private Image currentHealthImage;
    private EnemyFactory _enemy;
    private float fullHP=1000f, currentHP;
    [SerializeField] private float speedOfFlinig;
    
    void Start()
    {
        currentHP = fullHP;
    }
    
    private void Die()
    {
        
    }

    private void GetDamage(float hitForce)
    {
        if (currentHP > 0)
        {
            currentHP -= hitForce;
        }
        else
        {
            currentHP = 0;
        }
    }

    private void HPCounter()
    {
        currentHealthImage.fillAmount =
            Mathf.Lerp(currentHealthImage.fillAmount, currentHP / fullHP,Time.deltaTime*speedOfFlinig);
    }
}