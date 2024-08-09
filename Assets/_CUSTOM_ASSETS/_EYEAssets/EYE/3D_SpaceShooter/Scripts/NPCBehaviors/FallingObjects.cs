using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    float _step;
    [SerializeField] float _speed = -3f;
    [SerializeField] float _speedMultiplier = 1f;

    [SerializeField] float _upperSpawnPoint = 7f;
    [SerializeField] float _lowerSpawnPoint = -7f;

    void FixedUpdate()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime * -1;
        FallingObjectMovement();
        FallingObjectBoundaryBehavior();
    }

    void FallingObjectMovement()
    {
        transform.Translate(new Vector3(0, 0, _step));
    }

    void FallingObjectBoundaryBehavior()
    {
        if (transform.position.z < _lowerSpawnPoint)
            transform.position = new Vector3(Random.Range(-20f, 20f), 0, _upperSpawnPoint);
    }    
}
