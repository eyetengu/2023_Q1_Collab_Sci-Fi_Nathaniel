using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC_Activities : MonoBehaviour
{
    public bool _isWorking;

    [SerializeField] private bool _isAtWork;

    [SerializeField] private bool _isAtTarget;

    [SerializeField] Transform _workLocation;
    [SerializeField] Transform[] _workStations;

    Transform _currentDestination;

    [SerializeField] float _speed = 3;
    float _speedMultiplier = 1;
    float _step;
    float _workStationDuration;

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

    public virtual void MoveToDestination()
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

    public virtual void PerformWorkFunctions()
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

    public virtual void ChooseARandomStation()
    {
        _workStationDuration = Random.Range(1, 5f);
        _currentDestination = _workStations[Random.Range(0, _workStations.Length - 1)];
    }

    public virtual IEnumerator StationChangeTimer()
    {
        yield return new WaitForSeconds(_workStationDuration);
        _isReadyToChangeStations = true;
    }
}
