using UnityEngine;
using TMPro;

public class HealthText : HealthDisplay
{
    [SerializeField] private TextMeshProUGUI _display;

    protected override void OnChanged(float newValue, float newMaxValue)
    {
        _display.text = $"{(int)newValue}/{(int)newMaxValue}";
    }
}
