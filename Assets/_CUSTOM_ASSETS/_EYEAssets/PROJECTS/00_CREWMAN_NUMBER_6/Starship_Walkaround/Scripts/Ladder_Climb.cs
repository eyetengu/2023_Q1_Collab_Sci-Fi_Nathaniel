using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder_Climb : MonoBehaviour
{
    [SerializeField] Transform _ladderEnd;
    [SerializeField] float _climbSpeed = 2.2f;
    float _climbStep;
    bool _isMoving;
    Transform _playerTransform;


    void Start()
    {
        
    }

    void Update()
    {
        _climbStep = _climbSpeed * Time.deltaTime;


        if (_isMoving)
            MoveTowardsEndpoint();
    }

    void MoveTowardsEndpoint()
    {
        _playerTransform.position = _ladderEnd.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Trigger Entered");

            _playerTransform = other.transform;
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isMoving = true;
            }
        }
    }
}
