using System;
using UnityEngine;

abstract public class Item : MonoBehaviour
{
    [SerializeField] private int _value = 0;

    public int Value => _value;

    public event Action<Item> Collected;

    public void Collect()
    {
        Collected?.Invoke(this);
    }
}
