using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpSpeed = 7;
    [SerializeField] private float _jumpCooldown = 0.1f;

    private Rigidbody2D _rigidbody;
    private float _jumpCooldownCurrent = 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Mathf.Clamp01(Input.GetAxisRaw("Vertical"));

        transform.Translate(_speed * horizontalInput * Time.deltaTime * Vector2.right);

        if (IsGrounded())
        {
            _jumpCooldownCurrent = Mathf.Clamp(_jumpCooldownCurrent - Time.deltaTime, 0, _jumpCooldown);
            
            if (_jumpCooldownCurrent == 0 && verticalInput > 0)
            {
                _rigidbody.velocity += _jumpSpeed * verticalInput * Vector2.up;
                _jumpCooldownCurrent = _jumpCooldown;
            }
        }
    }

    private bool IsGrounded()
    {
        float distance = 0.5f;
        float radius = 0.2f;
        int layerMask = LayerMask.GetMask("Solid");
        bool isJumping = _rigidbody.velocity.y > 0;

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, Vector2.down, distance, layerMask);

        return hit.collider != null && isJumping == false;
    }
}
