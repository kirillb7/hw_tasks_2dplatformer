using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private const string Layer = "Solid";

    [SerializeField] private float _distance = 0.5f;
    [SerializeField] private float _radius = 0.2f;

    private int _layerMask;

    private void Awake()
    {
        _layerMask = LayerMask.GetMask(Layer);
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, _radius, Vector2.down, _distance, _layerMask);

        return hit.collider != null;
    }
}
