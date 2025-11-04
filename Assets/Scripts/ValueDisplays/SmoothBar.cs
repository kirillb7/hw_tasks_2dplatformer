using System.Collections;
using UnityEngine;

public class SmoothBar : Bar
{
    [SerializeField] private float _speed = 0f;

    private float _currentValue;
    private float _targetValue;
    private Coroutine _coroutine;

    protected override void Start()
    {
        base.Start();

        _currentValue = Display.value;
    }

    protected override void OnChanged(float newValue, float newMaxValue)
    {
        _targetValue = newValue / newMaxValue;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(UpdateValue());
    }

    private IEnumerator UpdateValue()
    {
        float step = 0f;

        while (_currentValue != _targetValue)
        {
            if (_speed > 0)
            {
                _currentValue = Mathf.Lerp(_currentValue, _targetValue, step);
                step += _speed * Time.deltaTime;
            }
            else
            {
                _currentValue = _targetValue;
            }

            Display.value = _currentValue;

            yield return null;
        }
    }
}
