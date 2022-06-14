using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Entity entity;

    private void Start()
    {
        SetMaxHealth(entity.MaxLife);
    }
    
    private void Update()
    {
        if (slider.value <= entity.life) return;
        
        slider.value -= (slider.value - entity.life) * Time.deltaTime;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
}
