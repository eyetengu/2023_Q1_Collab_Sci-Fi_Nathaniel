using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandbox_Rotations : MonoBehaviour
{
    [SerializeField] Transform _turretTransform;
    [SerializeField] Transform _barrelTransform;
    [SerializeField] Transform _targetTransform;

    float _speed = 2.0f;
    float _step;

    [SerializeField] int minX =325;
    [SerializeField] int maxX = 360;

    void Start()
    {
        
    }

    void Update()
    {
        _step = _speed * Time.deltaTime;

        RotateTurretBase();
    }

    void RotateTurretBase()
    {
        Vector3 targetDirection = transform.position - _targetTransform.position;

        var gatheredValue = Mathf.Clamp(targetDirection.y, minX, maxX);
        
        Vector3 newTurretDirection = Vector3.RotateTowards(_turretTransform.forward, new Vector3(targetDirection.x, 0, targetDirection.z), _step, 0.0f);
        Vector3 newBarrelDirection = Vector3.RotateTowards(_barrelTransform.forward, new Vector3(targetDirection.x, targetDirection.y, targetDirection.z), _step, 0.0f);

        _turretTransform.rotation = Quaternion.LookRotation(newTurretDirection);
        _barrelTransform.rotation = Quaternion.LookRotation(newBarrelDirection);
    }    
}
