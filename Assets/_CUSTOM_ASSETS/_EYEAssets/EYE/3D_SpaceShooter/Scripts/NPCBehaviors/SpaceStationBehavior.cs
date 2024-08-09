using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationBehavior : MonoBehaviour
{
    [SerializeField] private Transform[] _cwObjects;
    [SerializeField] private Transform[] _ccwObjects;
    [SerializeField] private float _rotationSpeed;


    void Update()
    {
        foreach(var obj in _cwObjects)        
            obj.transform.Rotate(0, -_rotationSpeed * Time.deltaTime, 0);        

        foreach(var obj in _ccwObjects)        
            obj.transform.Rotate(0, _rotationSpeed* Time.deltaTime, 0);        
    }
}
