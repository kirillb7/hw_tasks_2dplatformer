public class HealthCounter : Counter
{
    private new void Start()
    {
        Value = MaxValue;

        base.Start();
    }

    protected override void ChangeByItem(Item item)
    {
        if (item.TryGetComponent(out HealthItem healthItem))
        {
            Change(healthItem.Value);
        }
    }
}
