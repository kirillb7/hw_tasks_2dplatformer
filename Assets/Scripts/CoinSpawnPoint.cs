using UnityEngine;

public class CoinSpawnPoint : MonoBehaviour
{
    public bool IsAvailable()
    {
        int layerMask = LayerMask.GetMask("Coins");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0, layerMask);

        return hit.collider == null;
    }
}
