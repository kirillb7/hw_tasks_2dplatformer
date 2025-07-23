using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int _money = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _money += coin.Collect();
        }
    }
}
