using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpSpeed = 7;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        transform.Translate(_speed * direction * Time.deltaTime * Vector2.right, Space.World);
    }

    public void Jump()
    {
        _rigidbody.velocity += _jumpSpeed * Vector2.up;
    }
}
