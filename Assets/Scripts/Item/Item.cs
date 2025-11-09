using System;
using UnityEngine;

abstract public class Item : MonoBehaviour
{
    [SerializeField] private float _value = 0;

    public float Value => _value;

    public event Action<Item> Collected;

    public void Collect()
    {
        Collected?.Invoke(this);
    }
}
