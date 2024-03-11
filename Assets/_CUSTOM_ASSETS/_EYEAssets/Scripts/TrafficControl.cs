using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficControl : MonoBehaviour
{
    [SerializeField] Transform _pointA;
    [SerializeField] Transform _pointB;
    [SerializeField] Transform _sidepointC;
    [SerializeField] Transform _sidepointD;

    [SerializeField]
    bool _isMovingToA;
    float _step;
    [SerializeField]
    float _speed = 3;

    Transform _currentDestination;

    void Start()
    {
        
    }

    void Update()
    {
        _step = _speed * Time.deltaTime;

        if (_isMovingToA)
        {
            _currentDestination = _pointA;

            if (transform.position == _currentDestination.position)
            {
                _isMovingToA = false;
                _currentDestination = _pointB;
                transform.position = _sidepointC.position;
                transform.rotation = _sidepointC.rotation;
            }
        }
        else if(_isMovingToA == false)
        {
            _currentDestination = _pointB;

            if (transform.position == _pointB.position)
            {
                _isMovingToA = true;
                _currentDestination = _pointA;
                transform.position= _sidepointD.position;
                transform.rotation = _sidepointD.rotation;
            }
        }
        RotateTowardsCurrentTarget();

        transform.position = Vector3.MoveTowards(transform.position, _currentDestination.position, _step);
    }


    void RotateTowardsCurrentTarget()
    {
        var targetDirection = _currentDestination.position - transform.position;
        var newDirection = Vector3.RotateTowards(transform.forward, targetDirection, _step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }


}
