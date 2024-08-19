using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Waypoint_Follower : MonoBehaviour
{
    [Header("Waypoints")]
    [SerializeField] List<Transform> _waypoints;
    [SerializeField] Transform _currentTarget;
    int _waypointID;

    [Header("Conditions")]
    [SerializeField] bool _isLooping;
    [SerializeField] bool _isMovingForward;
    [SerializeField] bool _isRandom;
    [SerializeField] bool _pauseAtPoints;

    float _speed = 2.0f;
    float _speedMultiplier = 1.0f;
    float _step;

    float _distance;
    [SerializeField] float _delayDuration = 0.5f;

    void Start()
    {
        _currentTarget = _waypoints[0];
    }

    void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;
        MoveToCurrentWaypoint();
        TurnToFaceCurrentWaypoint();
        DistanceChecks();
    }

    void SelectNextWaypoint()
    {
        Debug.Log("Selecting Next");

        if (_isRandom)
        {
            _currentTarget = _waypoints[Random.Range(0, _waypoints.Count-1)];
        }
        else if (_isLooping)
        {
            if (_isMovingForward)
            {
                _waypointID++;
                if (_waypointID >= _waypoints.Count)
                    _waypointID = 0;
                _currentTarget = _waypoints[_waypointID];
            }
            else
            {
                _waypointID--;
                if(_waypointID < 0)
                    _waypointID = _waypoints.Count - 1;
                _currentTarget = _waypoints[_waypointID];
            }
        }
        else if (_isLooping == false)
        {
            if (_isMovingForward)
            {
                _waypointID++;
                if (_waypointID > _waypoints.Count - 1)
                {
                    _waypointID = _waypoints.Count - 2;
                    _isMovingForward = false;
                }
                _currentTarget = _waypoints[_waypointID];
            }
            else if(_isMovingForward == false)
            {
                _waypointID--;
                if(_waypointID < 0)
                {
                    _waypointID = 1;
                    _isMovingForward = true;
                }
                _currentTarget = _waypoints[_waypointID];
            }            
        }
    }

    void MoveToCurrentWaypoint()
    {
        Debug.Log("Moving To " + _currentTarget);
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _step);
    }

    void TurnToFaceCurrentWaypoint()
    {
        Debug.Log("Turning To Face " + _currentTarget);
        var targetDirection = _currentTarget.position - transform.position;
        var newDirection = Vector3.MoveTowards(transform.forward, targetDirection, _step);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    void DistanceChecks()
    {
        _distance = Vector3.Distance(transform.position, _currentTarget.position);

        if(_distance < 0.2f)
        {
            if (_pauseAtPoints)
                StartCoroutine(PauseAtPoint());
            else
                SelectNextWaypoint();
        }
    }

    IEnumerator PauseAtPoint()
    {
        Debug.Log("Pausing At Point");
        yield return new WaitForSeconds(_delayDuration);
        SelectNextWaypoint();
    }
}
