using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundObject : MonoBehaviour
{
    [SerializeField] Transform _targetTransform;
    [SerializeField] float _speed;
    float _step;


    void Update()
    {
        _step = _speed * Time.deltaTime;
        transform.RotateAround(_targetTransform.position, Vector3.up, _step);
    }
}
