using UnityEngine;

public class ItemSpawnPoint : MonoBehaviour
{
    private const string Layer = "Items";

    private int _layerMask;

    private void Awake()
    {
        _layerMask = LayerMask.GetMask(Layer);
    }

    public bool IsAvailable()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0, _layerMask);

        return hit.collider == null;
    }
}
