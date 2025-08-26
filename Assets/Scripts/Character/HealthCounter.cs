using UnityEngine;

public class HealthCounter : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    private int _health;
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

    private void Start()
    {
        _health = _maxHealth;
    }

    public void Heal(int amount)
    {
        _health = Mathf.Clamp(_health + amount, _health, _maxHealth);
    }

    public void Damage(int amount)
    {
        _health -= amount;
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
