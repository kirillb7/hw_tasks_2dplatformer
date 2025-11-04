using System;
using UnityEngine;

abstract public class Counter : MonoBehaviour
{
    [SerializeField] protected float MaxValue;

    protected float Value;
    protected ItemCollector ItemCollector;

    public event Action<float, float> Changed;

    private void Awake()
    {
        ItemCollector = GetComponent<ItemCollector>();
    }

    private void OnEnable()
    {
        if (ItemCollector != null)
        {
            ItemCollector.Collected += ChangeByItem;
        }
    }

    private void OnDisable()
    {
        if (ItemCollector != null)
        {
            ItemCollector.Collected -= ChangeByItem;
        }
    }

    protected void Start()
    {
        Changed?.Invoke(Value, MaxValue);
    }

    public void Change(float amount)
    {
        Value = Mathf.Clamp(Value + amount, 0, MaxValue);

        Changed?.Invoke(Value, MaxValue);
    }

    abstract protected void ChangeByItem(Item item);
}
