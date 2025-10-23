using UnityEngine;

abstract public class HealthDisplay : MonoBehaviour
{
    [SerializeField] protected HealthCounter Counter;

    private void OnEnable()
    {
        Counter.Changed += OnChanged;
    }

    private void OnDisable()
    {
        Counter.Changed -= OnChanged;
    }

    abstract protected void OnChanged(float newValue, float newMaxValue);
}
