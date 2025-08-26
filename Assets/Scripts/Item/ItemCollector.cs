using System;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public event Action<Item> Collected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            Collected?.Invoke(item);
            item.Collect();
        }
    }
}
