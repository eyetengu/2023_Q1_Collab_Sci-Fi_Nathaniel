using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweepo_RouteFollower : MonoBehaviour
{
    [SerializeField] Transform[] _route;
    [SerializeField] float _speed = 1.5f;
    
    Transform _currentWaypoint;

    int _routeID;
    
    bool _isMovingForward;
    
    float _sweepoStep = 1.0f;
    float _distance;
    [SerializeField] bool _looping;


//BUILT-IN FUNCTIONS
    void Start()
    {
        _currentWaypoint = _route[0];
        _isMovingForward = true;
    }

    void Update()
    {
        _sweepoStep = _speed * Time.deltaTime;
        MoveToCurrentWaypoint();

        _distance = Vector3.Distance(transform.position, _currentWaypoint.position);

        if (_distance < .15f)
            ChooseNewPoint();
    }


//CORE FUNCTIONS
    void ChooseNewPoint()
    {

        if (_looping)
        {
            if(_isMovingForward)
                _routeID++;
            else if(_isMovingForward == false)
                _routeID--;

            if (_routeID > _route.Length - 1)
                _routeID = 0;
            else if (_routeID < 0)
                _routeID = _route.Length - 1;
        }
        else
        {
            if (_isMovingForward)
               _routeID++;
            else if (_isMovingForward == false)
                _routeID--;

            if (_routeID > _route.Length - 1)
            {
                _isMovingForward = false;
                _routeID = _route.Length - 2;
            }
            else if (_routeID < 0)
            {
                _isMovingForward = true;
                _routeID = 1;
            }
        }
        _currentWaypoint = _route[_routeID];    
    }

    void MoveToCurrentWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint.position, _sweepoStep);
        TurnToFaceWaypoint();
    }

    void TurnToFaceWaypoint()
    {
        Vector3 targetDirection = _currentWaypoint.position - transform.position;
        Vector3 targetDirection2 = new Vector3(0, 0,targetDirection.z);
        var newDirection = Vector3.RotateTowards(transform.forward, targetDirection2, _sweepoStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

}
