using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(PlayerSprite))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(HealthCounter))]
[RequireComponent(typeof(Attacker))]
public class Player : MonoBehaviour
{
    [SerializeField] private Ability _ability;

    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private PlayerSprite _sprite;
    private Mover _mover;
    private Jumper _jumper;
    private Attacker _attacker;

    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
        _sprite = GetComponent<PlayerSprite>();
        _mover = GetComponent<Mover>();
        _jumper = GetComponent<Jumper>();
        _attacker = GetComponent<Attacker>();
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
            _jumper.Jump();
        }

        if (_inputReader.IsAttacking)
        {
            _attacker.Attack();
        }

        if (_ability != null && _inputReader.IsUsingAbility && _ability.IsAvailable)
        {
            _ability.Activate();
        }

        _sprite.Animate(direction);
    }
}
