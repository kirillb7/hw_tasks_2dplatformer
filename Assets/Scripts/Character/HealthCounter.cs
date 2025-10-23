using System;
using UnityEngine;

public class HealthCounter : MonoBehaviour
{
    [SerializeField] private int _maxValue = 100;

    private int _value;
    private ItemCollector _itemCollector;

    public event Action<float, float> Changed;

    public int Value => _value;
    public int MaxValue => _maxValue;

    private void Awake()
    {
        _itemCollector = GetComponent<ItemCollector>();
    }

    private void Start()
    {
        _value = _maxValue;

        Changed?.Invoke(_value, _maxValue);
    }

    private void OnEnable()
    {
        if (_itemCollector != null)
        {
            _itemCollector.Collected += ChangeByItem;
        }
    }

    private void OnDisable()
    {
        if (_itemCollector != null)
        {
            _itemCollector.Collected -= ChangeByItem;
        }
    }

    public void Heal(int amount)
    {
        if (amount > 0)
        {
            Change(amount);
        }
    }

    public void Damage(int amount)
    {
        if (amount > 0)
        {
            Change(-amount);
        }
    }

    private void Change(int amount)
    {
        _value = Mathf.Clamp(_value + amount, 0, _maxValue);

        Changed?.Invoke(_value, _maxValue);
    }

    private void ChangeByItem(Item item)
    {
        int value = item.HealthValue;

        if (value != 0)
        {
            if (value > 0)
            {
                Heal(value);
            }
            else
            {
                Damage(-value);
            }
        }
    }
}
