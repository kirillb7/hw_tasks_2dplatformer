using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(GroundDetector))]
public class Follower : MonoBehaviour
{
    [SerializeField] private float _jumpCooldown = 0.1f;

    private Mover _mover;
    private GroundDetector _groundDetector;
    private bool _canJump = true;
    private float _sufficientDistanceX = 1f;
    private float _sufficientDistanceY = 1f;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    public IEnumerator Follow(Transform target)
    {
        while (isActiveAndEnabled)
        {
            if (Mathf.Abs(target.position.x - transform.position.x) > _sufficientDistanceX)
            {
                _mover.Move(Mathf.Sign(target.position.x - transform.position.x));
            }

            if (_canJump && target.position.y - transform.position.y > _sufficientDistanceY)
            {
                _mover.Jump();

                StartCoroutine(StartJumpCooldown());
            }

            yield return null;
        }
    }

    private IEnumerator StartJumpCooldown()
    {
        _canJump = false;

        yield return new WaitForSeconds(_jumpCooldown);

        yield return new WaitUntil(() => _groundDetector.IsGrounded());

        yield return new WaitForSeconds(_jumpCooldown);

        _canJump = true;
    }
}
