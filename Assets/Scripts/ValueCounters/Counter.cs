using System;
using UnityEngine;

abstract public class Counter : MonoBehaviour
{
    [SerializeField] protected int MaxValue;

    protected int Value;
    protected ItemCollector ItemCollector;

    public event Action<int, int> Changed;

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

    public void Change(int amount)
    {
        Value = Mathf.Clamp(Value + amount, 0, MaxValue);

        Changed?.Invoke(Value, MaxValue);
    }

    abstract protected void ChangeByItem(Item item);
}
