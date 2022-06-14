using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public int newHealth;

    void Update()
    {
        if (slider.value > newHealth)
        {
            slider.value -= (slider.value - newHealth) * Time.deltaTime;
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        newHealth = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        newHealth = health;
    }
}
