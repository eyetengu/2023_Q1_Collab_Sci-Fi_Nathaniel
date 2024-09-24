using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [Header("TARGETS")]
    public Transform _homeBase;
    [SerializeField] Transform _currentTarget;
    [SerializeField] Transform[] _targetOptions;
    [SerializeField] int _targetIndex = 0;
    [SerializeField] bool _random;

    [Header("SPEED VALUES")]
    [SerializeField] float _speed = 4.0f;
    float _speedMultiplier = 1.0f;
    float _step;

    [Header("RANGES")]
    [SerializeField] float _firingRange;
    [SerializeField] float _recoveryDistance;
    [SerializeField] float _disengageRange;
    [SerializeField] float _circlingDistance = 100;

    [SerializeField] bool _disengageTarget;
    Enemy_Firing_Behavior _firingScript;
    Enemy_Turret_Behavior _turretScript;
    
    float _circlingSpeed = 0.1f;
    bool _hasDisengaged;

    public bool TargetInSights { get; set; }


//BUILT-IN FUNCTIONS
    private void Start()
    {
        _firingScript = GetComponent<Enemy_Firing_Behavior>();
        _turretScript = GetComponent<Enemy_Turret_Behavior>();

        CurrentTarget();
    }

    private void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;

        DistanceChecker();
    }


    //CORE FUNCTIONS
    void DistanceChecker()
    {
        if (_currentTarget != null)
        {
            float distance = Vector3.Distance(transform.position, _currentTarget.position);
            if (TargetInSights)
            {
                _currentTarget = _targetOptions[_targetIndex];
                if (distance < _disengageRange)
                    _disengageTarget = true;

                if (_disengageTarget)
                {
                    MoveAwayFromTarget();
                    TurnAwayFromTarget();

                    if (distance > _recoveryDistance)
                        _disengageTarget = false;
                }
                else        //if we are engaged with target
                {
                    MoveTowardTarget();
                    TurnToFaceTarget();

                    if (distance < _firingRange && distance > _disengageRange)
                    {
                        _firingScript.FireLaser();
                    }
                }
            }

            else
            {
                _currentTarget = _homeBase;

                if (distance < _circlingDistance)
                    RotateAroundTarget();
                else
                {
                    MoveTowardTarget();
                    TurnToFaceTarget();
                }
            }
        }
    }


//ENGAGE TARGET BEHAVIORS
    void MoveTowardTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _step);
    }

    void TurnToFaceTarget()
    {
        var targetDirection = _currentTarget.position - transform.position;
        var newDirection = Vector3.RotateTowards(transform.forward, targetDirection, _step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    
//DISENGAGE TARGET BEHAVIORS
    void MoveAwayFromTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, -_step);
    }

    void TurnAwayFromTarget()
    {
        var targetDirection = transform.position - _currentTarget.position;
        var newDirection = Vector3.RotateTowards(transform.forward, targetDirection, _step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }


//PATROLLING BEHAVIORS
    void RotateAroundTarget()
    {
        transform.RotateAround(_currentTarget.position, Vector3.up, _circlingSpeed);

        var targetDirection = _currentTarget.position - transform.position;
        var newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 0.1f, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
        

//TARGET FUNCTIONS
    void SelectNewTarget()
    {
        if (_random)        
            _targetIndex = Random.Range(0, _targetOptions.Length - 1);        
        else
        {
            _targetIndex++;

            if (_targetIndex > _targetOptions.Length - 1)
                _targetIndex = 0;
        }
        
        CurrentTarget();
    }  
    
    void CurrentTarget()
    {
        _currentTarget = _targetOptions[_targetIndex];
    }
    
    public void SetPlayerAsTarget()
    {
        _hasDisengaged = false; 
        var target = Random.Range(0, _targetOptions.Length - 1);
        _currentTarget = _targetOptions[target];
    }
    
    public void SetCourseForHome()
    {
        _hasDisengaged = true;
        _currentTarget = _homeBase;
    }
}
