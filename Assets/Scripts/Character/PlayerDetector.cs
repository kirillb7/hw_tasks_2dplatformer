using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private const string Layer = "Player";

    private int _layerMask;

    private void Awake()
    {
        _layerMask = LayerMask.GetMask(Layer);
    }

    public bool TryFind(float range, out Collider2D player)
    {
        player = Physics2D.OverlapCircle(transform.position, range, _layerMask);

        return player != null;
    }
}
