using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerSprite : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        _animator.SetBool("Is Running", horizontalInput != 0);

        if (horizontalInput > 0)
        {
            _renderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            _renderer.flipX = true;
        }
    }
}
