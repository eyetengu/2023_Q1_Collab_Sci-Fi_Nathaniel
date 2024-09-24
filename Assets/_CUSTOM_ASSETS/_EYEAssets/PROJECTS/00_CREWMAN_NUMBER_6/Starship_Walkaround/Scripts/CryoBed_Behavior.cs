using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryoBed_Behavior : MonoBehaviour
{
    UI_HUDManager _uiManager;
    [SerializeField] private Transform _cryobedLid;
    [SerializeField] private GameObject _lidGlass;
    [SerializeField] bool _lidIsClosed;

    [SerializeField] Transform _openLid, _closedLid, _sleepingInCryobed;
    [SerializeField] bool _isAsleep;
    [SerializeField] Transform _standingNearby;
    Transform _playerTransform;

    bool _playerInZone;


//BUILT-IN FUNCTIONS
    void Start()
    {
        _uiManager = FindObjectOfType<UI_HUDManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _playerInZone && _isAsleep)
        {
            WakeUp();
        }
        else if (Input.GetKeyDown(KeyCode.E) && _playerInZone && _isAsleep == false)
        {
            GoToSleep();
        }
    }


//CORE FUNCTIONS
    void OpenLid()
    {
        _cryobedLid.rotation = _openLid.rotation;
    }

    void CloseLid()
    {
        _cryobedLid.rotation = _closedLid.rotation;
    }

    void WakeUp()
    {
        _isAsleep = false;
        _playerTransform.position = _standingNearby.position;
        _playerTransform.rotation = _standingNearby.rotation;
        _playerTransform.SetParent(null);
    }

    void GoToSleep()
    {
        _isAsleep = true;
        _playerTransform.position = _sleepingInCryobed.position;
        _playerTransform.rotation = _sleepingInCryobed.rotation;
        _playerTransform.SetParent(transform);
        var animator = _playerTransform.GetComponent<PlayerAnimator>();
        //animator.LieDownAndSleep();
    }


    //TRIGGER FUNCTIONS
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _isAsleep == false)
        {
            Debug.Log("Player Detected");
            _playerInZone = true;
            _playerTransform = other.transform;
            
            if (_lidIsClosed)
            {
                _lidIsClosed = false;
                OpenLid();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
         
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" && _isAsleep == false)
        {
            Debug.Log("Player Exiting");
            _playerInZone = false;
            _playerTransform = null;

            if (_lidIsClosed == false)
            {
                _lidIsClosed = true;
                CloseLid();
            }        
        }
    }
}
