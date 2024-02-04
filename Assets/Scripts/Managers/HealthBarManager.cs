using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Slider easeSlider;
    [SerializeField] private float _maxHealth;
    private float _currentHealth;
    private float _easeSpeed=0.03f;
    
    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float currentHealth)
    {
        _currentHealth = currentHealth;
        StartCoroutine(ChangeSliderValue());
    }

    private IEnumerator ChangeSliderValue()
    {
        if (slider.value != _currentHealth)
        {
            slider.value = _currentHealth;
        }

        while(easeSlider.value!=slider.value)
        {
            easeSlider.value = Mathf.Lerp(easeSlider.value, _currentHealth, _easeSpeed);
            
            yield return null;
        }
    }
}
