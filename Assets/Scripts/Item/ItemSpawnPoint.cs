using UnityEngine;

public class ItemSpawnPoint : MonoBehaviour
{
    private const string Layer = "Items";

    public bool IsAvailable()
    {
        int layerMask = LayerMask.GetMask(Layer);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0, layerMask);

        return hit.collider == null;
    }
}
