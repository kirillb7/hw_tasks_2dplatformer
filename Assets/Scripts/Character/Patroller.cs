using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Patroller : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    private Mover _mover;
    private Transform _currentWaypoint;
    private int _currentWaypointIndex = 0;
    private float _sufficientDistanceToWaypoint = 0.1f;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Start()
    {
        SetNextWaypoint();
    }

    private void Update()
    {
        _mover.Move(Mathf.Sign(_currentWaypoint.position.x - transform.position.x));

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
