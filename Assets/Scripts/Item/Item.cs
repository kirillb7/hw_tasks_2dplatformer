using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int _healthValue = 0;
    [SerializeField] private int _moneyValue = 0;

    public int HealthValue => _healthValue;
    public int MoneyValue => _moneyValue;

    public event Action<Item> Collected;

    public void Collect()
    {
        Collected?.Invoke(this);
    }
}
