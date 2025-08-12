using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(PlayerSprite))]
[RequireComponent(typeof(Mover))]
public class Player : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private PlayerSprite _playerSprite;
    private Mover _mover;

    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
        _playerSprite = GetComponent<PlayerSprite>();
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        float direction = _inputReader.Direction;

        if (direction != 0)
        {
            _mover.Move(direction);
        }

        if (_inputReader.IsJumping && _groundDetector.IsGrounded())
        {
            _mover.Jump();
        }

        _playerSprite.Animate(direction);
    }
}
