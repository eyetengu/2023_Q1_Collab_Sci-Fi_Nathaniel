using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStation_Behavior : MonoBehaviour
{
    [SerializeField] Transform _upperRing;
    [SerializeField] Transform _mainRing;
    [SerializeField] Transform _lowerRing;

    [SerializeField] private float _rotationSpeed = 10;

    
    void Update()
    {
        RotateRings();
    }

    void RotateRings()
    {
        _upperRing.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
        _mainRing.Rotate(0, -_rotationSpeed * Time.deltaTime, 0);
        _lowerRing.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }



}
