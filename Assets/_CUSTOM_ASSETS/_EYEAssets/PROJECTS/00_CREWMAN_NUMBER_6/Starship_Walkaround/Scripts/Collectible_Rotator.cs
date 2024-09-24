using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Rotator : MonoBehaviour
{
    [Header("ROTATION SPEED")]
    [SerializeField] float _rotationSpeed = 1;
    
    [Header("ROTATION AXES")]
    [SerializeField] private bool _xAxis;
    [SerializeField] private bool _yAxis;
    [SerializeField] private bool _zAxis;


    void Update()
    {
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
        transform.Rotate(_rotationSpeed, 0, 0);
    }

    void RotateOnYAxis()
    {
        transform.Rotate(0, _rotationSpeed, 0);
    }

    void RotateOnZAxis()
    {
        transform.Rotate(0, 0, _rotationSpeed);
    }
}
