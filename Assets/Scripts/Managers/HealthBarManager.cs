using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Slider easeSlider;
    [SerializeField] private float _maxHealth;
    private float _currentHealth;
    private float _easeSpeed=0.5f;
    
    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float currentHealth)
    {
        _currentHealth = currentHealth;
        ChangeSliderValue();
    }

    private void ChangeSliderValue()
    {
        /*if (slider.value != _currentHealth)
        {
            slider.value = _currentHealth;
        }*/

        if (slider.value!=easeSlider.value)
        {
            easeSlider.value = Mathf.Lerp(easeSlider.value, _currentHealth, _easeSpeed);
        }
    }
}
