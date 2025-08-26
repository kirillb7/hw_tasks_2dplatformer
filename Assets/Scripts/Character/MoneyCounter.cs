using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    private int _money = 0;
    private ItemCollector _itemCollector;

    private void Awake()
    {
        _itemCollector = GetComponent<ItemCollector>();
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

    private void ChangeByItem(Item item)
    {
        int value = item.MoneyValue;

        if (value != 0)
        {
            if (value > 0)
            {
                Gain(value);
            }
            else
            {
                Lose(-value);
            }
        }
    }

    private void Gain(int amount)
    {
        _money += amount;
    }

    private void Lose(int amount)
    {
        _money = Mathf.Clamp(_money - amount, 0, _money);
    }
}
