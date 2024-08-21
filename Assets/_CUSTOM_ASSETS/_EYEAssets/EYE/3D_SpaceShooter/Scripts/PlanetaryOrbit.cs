using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryOrbit : MonoBehaviour
{
    [SerializeField] Transform _orbitTarget;
    [SerializeField] float _rotationSpeed = 3f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(_orbitTarget.position, Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
