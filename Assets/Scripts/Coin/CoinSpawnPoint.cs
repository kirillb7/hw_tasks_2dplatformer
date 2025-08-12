using UnityEngine;

public class CoinSpawnPoint : MonoBehaviour
{
    private const string _coinsLayer = "Coins";

    public bool IsAvailable()
    {
        int layerMask = LayerMask.GetMask(_coinsLayer);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0, layerMask);

        return hit.collider == null;
    }
}
