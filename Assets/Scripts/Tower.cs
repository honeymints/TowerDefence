using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject slider;
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
            currentHP -= hitForce;
            slider.GetComponent<HealthBarManager>().TakeDamage(currentHP);
        }
        else
        {
            currentHP = 0;
            Die();
        }
    }
}
