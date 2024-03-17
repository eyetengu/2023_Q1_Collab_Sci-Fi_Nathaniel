using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    float _speedMultiplier = 1f;
    float _step;
    [SerializeField] bool _rotateX;
    [SerializeField] bool _rotateY;
    [SerializeField] bool _rotateZ;


    void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;

        if (_rotateX)
            transform.Rotate(_step, 0, 0);
        else if (_rotateY)
            transform.Rotate(0, _step, 0);
        else if (_rotateZ)
            transform.Rotate(0, 0, _step);
        else
            transform.Rotate(0, 0, 0);

    }
}
