using UnityEngine;
using UnityEngine.UI;

public class HealthBar : HealthDisplay
{
    [SerializeField] protected Slider Display;

    protected virtual void Start()
    {
        Display.interactable = false;
        Display.minValue = 0;
        Display.maxValue = 1;
    }

    protected override void OnChanged(float newValue, float newMaxValue)
    {
        Display.value = newValue / newMaxValue;
    }
}
