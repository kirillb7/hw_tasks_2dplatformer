using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private const string _groundLayer = "Solid";

    public bool IsGrounded()
    {
        float distance = 0.5f;
        float radius = 0.2f;
        int layerMask = LayerMask.GetMask(_groundLayer);

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, Vector2.down, distance, layerMask);

        return hit.collider != null;
    }
}
