using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    float _step;
    [SerializeField] private float _speed = 1;
    [SerializeField] Vector3 _rotationValues;    
    

    void Start()
    {
        
    }

    void Update()
    {
        _step = _speed * Time.deltaTime;
        transform.Rotate(_rotationValues * _step);
    }
}
