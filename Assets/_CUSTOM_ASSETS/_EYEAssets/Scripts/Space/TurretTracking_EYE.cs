using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTracking_EYE : MonoBehaviour
{
    [SerializeField]
    Transform _currentThreat;
    float _distanceToThreat;
    [SerializeField]
    GameObject[] _enemies;
    [SerializeField]
    List<GameObject> _threats;
    float _distanceValue;
    bool _isInRange;
    float _step;
    float _speed = 5;


    void Start()
    {
        
    }

    void Update()
    {
        _step = _speed * Time.deltaTime;

        _enemies = GameObject.FindGameObjectsWithTag("Enemy");

        ThreatAnalysis();
        EngageTarget();
    }

    void EngageTarget()
    {
        var targetDirection = transform.position - _currentThreat.position;
        var targetDirection_Yaw = new Vector3(targetDirection.x, 0,0);
        var newDirection = Vector3.RotateTowards(transform.forward, targetDirection_Yaw, _step, 0.0f);
        transform.rotation= Quaternion.LookRotation(newDirection);
    }

    void ThreatAnalysis()
    {
        foreach (var enemy in _enemies)
        {
            _distanceToThreat = Vector3.Distance(transform.position, enemy.transform.position);

            if(_distanceValue == 0)
                _distanceValue= _distanceToThreat;
            else
            {
                if (_distanceToThreat < _distanceValue)
                { _distanceValue = _distanceToThreat;
                    _currentThreat = enemy.transform;
                }
            }
            
            if (_distanceToThreat < 8)
            {
                if (_isInRange == false)
                {
                    _isInRange = true;
                    _threats.Add(enemy);                 
                }
            }
            else
            {
                _threats.Remove(enemy);
                _isInRange = false;
            }            
        }
    }
}
