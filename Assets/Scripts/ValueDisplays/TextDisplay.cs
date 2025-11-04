using UnityEngine;
using TMPro;

public class TextDisplay : ValueDisplay
{
    [SerializeField] private TextMeshProUGUI _display;
    [SerializeField] private bool _isShowingMaxValue;

    protected override void OnChanged(float newValue, float newMaxValue)
    {
        string text = $"{(int)newValue}";

        if (_isShowingMaxValue)
        {
            text += $"/{(int)newMaxValue}";
        }

        _display.text = text;
    }
}
