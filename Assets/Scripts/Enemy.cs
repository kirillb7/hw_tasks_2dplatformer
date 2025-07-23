using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private Transform[] _waypoints;

    private Transform _currentWaypoint;
    private int _currentWaypointIndex = 0;
    private float _sufficientDistanceToWaypoint = 0.1f;

    private void Start()
    {
        SetNextWaypoint();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _currentWaypoint.position, _speed * Time.deltaTime);

        if ((_currentWaypoint.position - transform.position).sqrMagnitude <= _sufficientDistanceToWaypoint * _sufficientDistanceToWaypoint)
        {
            SetNextWaypoint();
        }
    }

    private void SetNextWaypoint()
    {
        _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;
        _currentWaypoint = _waypoints[_currentWaypointIndex];
    }
}
