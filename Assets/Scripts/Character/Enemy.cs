using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Patroller))]
[RequireComponent(typeof(Follower))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(HealthCounter))]
[RequireComponent(typeof(PlayerDetector))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _attackCooldown = 0.1f;
    [SerializeField] private float _visionRange = 1.6f;

    private bool _canAttack = true;
    private bool _isFollowing = false;

    private Patroller _patroller;
    private Follower _follower;
    private Attacker _attacker;
    private PlayerDetector _playerDetector;

    private void Awake()
    {
        _patroller = GetComponent<Patroller>();
        _follower = GetComponent<Follower>();
        _attacker = GetComponent<Attacker>();
        _playerDetector = GetComponent<PlayerDetector>();
    }

    private void Update()
    {
        if (_isFollowing)
        {
            if (_playerDetector.TryFindPlayer(_attacker.Range, out _) && _canAttack)
            {
                _attacker.Attack();

                StartCoroutine(StartAttackCooldown());
            }
        }
        else
        {
            if (_playerDetector.TryFindPlayer(_visionRange, out Collider2D player))
            {
                _patroller.enabled = false;
                _isFollowing = true;

                _follower.StartCoroutine(_follower.Follow(player.transform));
            }
        }
    }

    private IEnumerator StartAttackCooldown()
    {
        _canAttack = false;

        yield return new WaitForSeconds(_attackCooldown);

        _canAttack = true;
    }
}
