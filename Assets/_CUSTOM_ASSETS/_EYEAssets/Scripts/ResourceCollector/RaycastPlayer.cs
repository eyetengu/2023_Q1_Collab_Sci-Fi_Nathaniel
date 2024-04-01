using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 _targetDestination;
    float _step;
    [SerializeField] private float _speed = 3f;
    float _speedMultiplier = 1.0f;


    private void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;

        var distance = Vector3.Distance(transform.position, _targetDestination);
        if (distance > 1.0f) 
        { 
            var targetDirection = _targetDestination - transform.position;
            targetDirection.Normalize();

            transform.Translate(targetDirection * _step);
        }
    }

    public void UpdateDestination(Vector3 destination)
    {
        Debug.Log("Here in the player");
        destination.y = -1.9f;
        _targetDestination = destination;
    }
}
