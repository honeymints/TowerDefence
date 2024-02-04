using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Slider easeSlider;
    [SerializeField] private float _maxHealth;
    private float _currentHealth;
    private float _easeSpeed=0.05f;

    private Camera cam;
    private void Start()
    {
        cam=Camera.main;
        _currentHealth = _maxHealth;
    }
    
    private void LateUpdate()
    {
        transform.LookAt(transform.position+cam.transform.position);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        ChangeSliderValue();
    }

    private void ChangeSliderValue()
    {
        if (slider.value != _currentHealth)
        {
            slider.value = _currentHealth;
        }

        if (slider.value!=easeSlider.value)
        {
            easeSlider.value = Mathf.Lerp(easeSlider.value, _currentHealth, _easeSpeed);
        }
    }
}
