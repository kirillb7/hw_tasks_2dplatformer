public class HealthCounter : Counter
{
    private new void Start()
    {
        Value = MaxValue;

        base.Start();
    }

    public void Heal(float amount)
    {
        if (amount > 0)
        {
            Change(amount);
        }
    }

    public void Damage(float amount)
    {
        if (amount > 0)
        {
            Change(-amount);
        }
    }

    protected override void ChangeByItem(Item item)
    {
        if (item.TryGetComponent(out HealthItem healthItem))
        {
            float amount = healthItem.Value;

            if (amount > 0)
            {
                Heal(amount);
            }
            else if (amount < 0)
            {
                Damage(-amount);
            }
        }
    }
}
