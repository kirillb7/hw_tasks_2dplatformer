using UnityEngine;
using UnityEngine.UI;

public class Bar : ValueDisplay
{
    [SerializeField] protected Slider Display;

    protected virtual void Start()
    {
        Display.interactable = false;
        Display.minValue = 0;
        Display.maxValue = 1;
    }

    protected override void OnChanged(int newValue, int newMaxValue)
    {
        Display.value = (float)newValue / newMaxValue;
    }
}
