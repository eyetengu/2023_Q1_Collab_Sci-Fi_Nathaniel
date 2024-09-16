using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator_BackAndForth : MonoBehaviour
{
    [Header("ROTATION SPEED")]
    [SerializeField] float _rotationSpeed = 1.0f;

    [Header("ROTATION AXES")]
    [SerializeField] private bool _xAxis;
    [SerializeField] private bool _yAxis;
    [SerializeField] private bool _zAxis;

    [SerializeField] private bool _oscillating;
    [SerializeField] private float _oscillationRate;
    [SerializeField] private int _directionIndicator = 1;

    //private bool _rotatingRight;
    private bool _readyToRotate = true;

    void Update()
    {
        if(_readyToRotate)
        {
            _readyToRotate = false;
            StartCoroutine(OscillationSpeed());
        }

        if (_xAxis)
            RotateOnXAxis();
        else if (_yAxis)
            RotateOnYAxis();
        else if (_zAxis)
            RotateOnZAxis();
    }

    //CORE FUNCTIONS
    void RotateOnXAxis()
    {
        if(_oscillating)        
            transform.Rotate(_rotationSpeed * _directionIndicator, 0, 0);
        else
            transform.Rotate(_rotationSpeed, 0, 0);
    }

    void RotateOnYAxis()
    {
        if(_oscillating)
            transform.Rotate(0, _rotationSpeed * _directionIndicator, 0);

        else
            transform.Rotate(0, _rotationSpeed, 0);
    }

    void RotateOnZAxis()
    {
        if (_oscillating)
            transform.Rotate(0, 0, _rotationSpeed * _directionIndicator);
        else
            transform.Rotate(0, 0, _rotationSpeed);
    }


    IEnumerator OscillationSpeed()
    {
        yield return new WaitForSeconds(_oscillationRate);
        //_rotatingRight = !_rotatingRight;
        _directionIndicator *= -1;
        _readyToRotate = true;
    }

}
