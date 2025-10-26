public class MoneyCounter : Counter
{
    protected override void ChangeByItem(Item item)
    {
        if (item.TryGetComponent(out MoneyItem moneyItem))
        {
            Change(moneyItem.Value);
        }
    }
}
