using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkScript : MonoBehaviour
{
    public bool _isWorking;
    [SerializeField] private bool _isAtWork;
    [SerializeField] private bool _isAtTarget;

    /// <summary>
    /// Here in the work script we will develop the characters work habits.
    /// the character will GoToWork()
    /// when the character arrives at work he will PerformWorkFunctions()
    /// move from one location to another and perform actions/animations that are appropriate for this character
    /// </summary>
    
    [SerializeField] Transform _workLocation;
    [SerializeField] Transform[] _workStations;
    Transform _currentDestination;

    [SerializeField] float _speed = 3;
    float _speedMultiplier = 1;
    float _step;
    float _workStationDuration;
    Transform[] _workZones;

    float _distanceToTarget;
    bool _isReadyToChangeStations;


    void Start()
    {
        _currentDestination = _workLocation;
        _isAtWork = false;

        var locationList = _workLocation.gameObject.GetComponent<RoomWaypoint>();
        _workStations = locationList._workZones;
        _isReadyToChangeStations = true;

    }

    void Update()
    {
        if (_isWorking)
        {
            _step = _speed * _speedMultiplier * Time.deltaTime;

            if (_isAtWork)
            {
                PerformWorkFunctions();
            }
            else
                _currentDestination = _workLocation;

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

            if (_isAtTarget && _currentDestination == _workLocation)
                _isAtWork = true;
        }
    }

    void PerformWorkFunctions()
    {
        Debug.Log("Performing Work Functions");
        if(_isReadyToChangeStations)
        {
            _isReadyToChangeStations = false;
            ChooseARandomStation();
            StartCoroutine(StationChangeTimer());
        }

        MoveToDestination();
    }

    void ChooseARandomStation()
    {
        _workStationDuration = Random.Range(1, 5f);
        _currentDestination = _workStations[Random.Range(0, _workStations.Length - 1)];
    }

    IEnumerator StationChangeTimer()
    {
        yield return new WaitForSeconds(_workStationDuration);
        _isReadyToChangeStations = true;
    }
}
