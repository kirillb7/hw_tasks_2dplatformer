using UnityEngine;

abstract public class ValueDisplay : MonoBehaviour
{
    [SerializeField] protected Counter Counter;

    private void OnEnable()
    {
        Counter.Changed += OnChanged;
    }

    private void OnDisable()
    {
        Counter.Changed -= OnChanged;
    }

    abstract protected void OnChanged(int newValue, int newMaxValue);
}
