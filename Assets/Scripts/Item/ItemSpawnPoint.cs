using UnityEngine;

public class ItemSpawnPoint : MonoBehaviour
{
    private const string _itemsLayer = "Items";

    public bool IsAvailable()
    {
        int layerMask = LayerMask.GetMask(_itemsLayer);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0, layerMask);

        return hit.collider == null;
    }
}
