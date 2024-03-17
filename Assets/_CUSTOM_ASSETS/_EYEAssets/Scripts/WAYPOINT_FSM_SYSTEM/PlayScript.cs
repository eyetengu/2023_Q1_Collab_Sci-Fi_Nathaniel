using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScript : MonoBehaviour
{
    public bool _isPlaying;
    private bool _inCantina;
    private bool _isAtTarget;

    [SerializeField] private Transform _cantina;
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
        _currentDestination = _cantina;
        _inCantina = false;

        var locationList = _cantina.gameObject.GetComponent<RoomWaypoint>();
        _workStations = locationList._workZones;
    }
    void Update()
    {

        if (_isPlaying)
        {
            Debug.Log("Rest Script Activated");
            _step = _speed * _speedMultiplier * Time.deltaTime;

            if (_inCantina)
                PerformWorkFunctions();
            else
                _currentDestination = _cantina;

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

            if (_isAtTarget && _currentDestination == _cantina)
                _inCantina = true;
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
