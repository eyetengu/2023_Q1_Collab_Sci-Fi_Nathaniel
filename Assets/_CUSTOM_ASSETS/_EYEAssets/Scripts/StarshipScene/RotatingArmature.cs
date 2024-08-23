using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingArmature : MonoBehaviour
{
    [SerializeField] Vector3 _objectRotation;

    float _step;
    float _xStep;
    float _yStep;
    float _zStep;
    
    [SerializeField] float _speed = 8f;
    float _speedMultiplier = 1f;
    [SerializeField] private bool _isSwitching;
    bool _isReadyToSwitch;

    [SerializeField] float _rotationDuration;


    private void Start()
    {
        _isReadyToSwitch = true;
    }

    void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;
        _xStep = _objectRotation.x * _step;
        _yStep = _objectRotation.y * _step;
        _zStep = _objectRotation.z * _step;

        RotateObject();

        if (_isSwitching)
        {
            if (_isReadyToSwitch)
            {
                _isReadyToSwitch = false;
                SwitchTheYield();
            }
        }
    }

    void RotateObject()
    {
        transform.Rotate(_xStep, _yStep, _zStep);
    }

    void SwitchTheYield()
    {
        StartCoroutine(RotationTimer());
    }


    IEnumerator RotationTimer()
    {
        yield return new WaitForSeconds(_rotationDuration);
        _speedMultiplier *= -1;
        SwitchTheYield();
    }
}
