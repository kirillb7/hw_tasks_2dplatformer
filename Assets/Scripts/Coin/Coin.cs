using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value = 1;

    public event Action<Coin> Collected;

    public int Collect()
    {
        Collected?.Invoke(this);

        return _value;
    }
}
