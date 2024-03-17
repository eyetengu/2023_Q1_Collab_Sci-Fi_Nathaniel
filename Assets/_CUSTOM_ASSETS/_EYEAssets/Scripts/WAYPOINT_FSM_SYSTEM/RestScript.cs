using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RestScript : MonoBehaviour
{
    public bool _isResting;
    private bool _inQuarters;
    private bool _isAtTarget;

    [SerializeField] private Transform _crewQuarters;
    [SerializeField] private Transform[] _workStations;
    Transform _currentDestination;

    float _speed = 3.0f;
    float _speedMultiplier = 1.0f;
    float _step;
    float _restStationDuration;
    Transform[] _workZones;

    float _distanceToTarget;
    bool _isReadyToChangeStations;


    private void Start()
    {
        _currentDestination = _crewQuarters;
        _inQuarters = false;

        var locationList = _crewQuarters.gameObject.GetComponent<RoomWaypoint>();
        _workStations = locationList._workZones;
    }
    
    void Update()
    {

        if (_isResting)
        {
            Debug.Log("Rest Script Activated");
            _step = _speed * _speedMultiplier * Time.deltaTime;
            
            if(_inQuarters)            
                PerformWorkFunctions();            
            else            
                _currentDestination = _crewQuarters;
                
            MoveToDestination();            
        }
    }

    void MoveToDestination()
    {
        _distanceToTarget = Vector3.Distance(transform.position, _currentDestination.position);

        if (_distanceToTarget > .2f)
        {
            _isAtTarget = false;

            transform.position = Vector3.MoveTowards(transform.position, _currentDestination.position, _step);
        }
        else
        {
            _isAtTarget = true;

            if (_isAtTarget && _currentDestination == _crewQuarters)
                _inQuarters = true;
        }
    }

    void PerformWorkFunctions()
    {
        Debug.Log("Performing Work Functions");
        if (_isReadyToChangeStations)
        {
            _isReadyToChangeStations = false;
            ChooseARandomStation();
            StartCoroutine(StationChangeTimer());
        }

        MoveToDestination();
    }

    void ChooseARandomStation()
    {
        _restStationDuration = Random.Range(1, 5f);
        _currentDestination = _workStations[Random.Range(0, _workStations.Length - 1)];
    }

    IEnumerator StationChangeTimer()
    {
        yield return new WaitForSeconds(_restStationDuration);
        _isReadyToChangeStations = true;
    }
}
