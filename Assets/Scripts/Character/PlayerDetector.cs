using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private const string _playerLayer = "Player";

    public bool TryFindPlayer(float range, out Collider2D player)
    {
        int layerMask = LayerMask.GetMask(_playerLayer);

        player = Physics2D.OverlapCircle(transform.position, range, layerMask);

        return player != null;
    }
}
