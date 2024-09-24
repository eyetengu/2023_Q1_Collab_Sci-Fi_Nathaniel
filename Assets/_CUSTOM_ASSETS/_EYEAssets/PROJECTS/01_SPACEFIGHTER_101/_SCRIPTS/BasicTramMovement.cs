using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTramMovement : MonoBehaviour
{
    float _speed = 2.0f;
    float _step;
    void Start()
    {
        
    }


    void Update()
    {
        _step = _speed * Time.deltaTime;
        transform.Translate( new Vector3(0, 0, _step));
    }
}
