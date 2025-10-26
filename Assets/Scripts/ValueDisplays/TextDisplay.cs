using UnityEngine;
using TMPro;

public class TextDisplay : ValueDisplay
{
    [SerializeField] private TextMeshProUGUI _display;
    [SerializeField] private bool _isShowingMaxValue;

    protected override void OnChanged(int newValue, int newMaxValue)
    {
        string text = $"{newValue}";

        if (_isShowingMaxValue)
        {
            text += $"/{newMaxValue}";
        }

        _display.text = text;
    }
}
