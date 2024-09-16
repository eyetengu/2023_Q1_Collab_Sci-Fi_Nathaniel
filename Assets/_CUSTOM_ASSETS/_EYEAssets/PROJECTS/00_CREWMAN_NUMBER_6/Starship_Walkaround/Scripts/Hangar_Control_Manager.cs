using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangar_Control_Manager : MonoBehaviour
{
    [SerializeField] bool _doorsOpening;
    [SerializeField] Transform _doorLeft, _doorRight;
    [SerializeField] Transform _doorOpenedL, _doorClosedL;
    [SerializeField] Transform _doorOpenedR, _doorClosedR;
    Transform _currentDestinationL, _currentDestinationR;

    [SerializeField] float _speed;
    float _step;
    bool _isClosing;
    bool _isOpening;


//BUILT-IN FUNCTIONS
    void Start()
    {
        //if (_isClosing)
        //{

        //}
        //else
        //{
            _currentDestinationL = _doorOpenedL;
            _currentDestinationR = _doorOpenedR;
        //}
    }

    void Update()
    {
        _step = _speed * Time.deltaTime;
        
        DistanceChecker();

        if(_doorsOpening)
            OpenHangarDoors();

        else if (_doorsOpening == false)
            CloseHangarDoors();
    }


//CORE FUNCTIONS
    void DistanceChecker()
    {
        var distance = Vector3.Distance(_currentDestinationL.position, transform.position);

        if (distance < .15f && _isClosing)
            _isClosing = false;

        else if (distance < .15f && _isClosing == false)
            _isClosing = true;
    }

    void EngageHangarDoors()
    {
        Debug.Log("Engaging Doors: " + _doorsOpening);
        _doorsOpening = !_doorsOpening;

        if (_doorsOpening)
        {
            _currentDestinationL = _doorOpenedL;
            _currentDestinationR = _doorOpenedR;
            OpenHangarDoors();
        }

        else
        {
            _currentDestinationL = _doorClosedL;
            _currentDestinationR = _doorClosedR;
            CloseHangarDoors();
        }
    }

    void OpenHangarDoors()
    {
        _doorLeft.position = Vector3.MoveTowards(_doorLeft.position, _currentDestinationL.position, _step);
        _doorRight.position = Vector3.MoveTowards(_doorRight.position, _currentDestinationR.position, _step);
    }

    void CloseHangarDoors()
    {
        _doorLeft.position = Vector3.MoveTowards(_doorLeft.position, _currentDestinationL.position, _step);
        _doorRight.position = Vector3.MoveTowards(_doorRight.position, _currentDestinationR.position, _step);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Pressing Button");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Doors Opening: "+ !_doorsOpening);
                EngageHangarDoors();
            }
        }
    }    
}
