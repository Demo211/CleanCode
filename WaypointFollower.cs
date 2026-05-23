using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _route;

    private Transform[] _waypoints;
    private int _waypointNumber = 0;

    private Transform _currentTargetWaypoint;

    private void Start()
    {
        _waypoints = new Transform[_route.childCount];

        for (int i = 0; i < _route.childCount; i++)
            _waypoints[i] = _route.GetChild(i);

        _currentTargetWaypoint = _waypoints[_waypointNumber];
    }

    private void Update()
    {
        transform.position   =  Vector3.MoveTowards(transform.position , _currentTargetWaypoint.position, _speed * Time.deltaTime);

        if (transform.position == _currentTargetWaypoint.position)
            SetNextWaypoint();
    }

    private void SetNextWaypoint()
    {
        _waypointNumber++;
        
        if (_waypointNumber == _waypoints.Length)
            _waypointNumber  = 0;

        _currentTargetWaypoint = _waypoints[_waypointNumber];
        transform.forward = _currentTargetWaypoint.transform.position - transform.position;        
    }
}