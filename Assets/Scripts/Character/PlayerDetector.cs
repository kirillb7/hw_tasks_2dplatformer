using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private const string Layer = "Player";

    public bool TryFind(float range, out Collider2D player)
    {
        int layerMask = LayerMask.GetMask(Layer);

        player = Physics2D.OverlapCircle(transform.position, range, layerMask);

        return player != null;
    }
}
