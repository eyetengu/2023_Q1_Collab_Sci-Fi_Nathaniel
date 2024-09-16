using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_DoubleSlide : MonoBehaviour
{
    [SerializeField] Transform _doorLeft;
    [SerializeField] Transform _doorRight;

    [SerializeField] Transform _openLeftPos;
    [SerializeField] Transform _closedLeftPos;

    [SerializeField] Transform _openRightPos;
    [SerializeField] Transform _closedRightPos;

    bool _isOpen;


    //BUILT-IN FUNCTIONS
    private void Start()
    {
        DoorsClosed();
    }


    //CORE FUNCTIONS
    void DoorsOpen()
    {
        _doorLeft.position = _openLeftPos.position;
        _doorRight.position = _openRightPos.position;
    }

    void DoorsClosed()
    {
        _doorLeft.position = _closedLeftPos.position;
        _doorRight.position = _closedRightPos.position;
    }


    //TRIGGER FUNCTIONS
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player" || other.tag == "Maintenance") && _isOpen == false)
        {
            DoorsOpen();
            _isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Player" || other.tag == "Maintenance") && _isOpen)
        {
            DoorsClosed();
            _isOpen = false;
        }
    }
}
