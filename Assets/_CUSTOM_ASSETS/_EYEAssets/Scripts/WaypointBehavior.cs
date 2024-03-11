using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointBehavior : MonoBehaviour
{
    private AreaMap _areaMap;
    [SerializeField] private Transform _waypointStart;
    private Transform[] _availableWaypoints;
    private Transform _currentWaypoint;
    private int _waypointID;

    [SerializeField] private float _speed = 4;
    [SerializeField] private float _rotationSpeed = 10;
    private float _step;
    private float _rotationStep;


    private void Start()
    {
        _currentWaypoint = _waypointStart;
        Debug.Log("Starting Waypoint: " + _currentWaypoint);
    }

    private void Update()
    {
        _step = _speed * Time.deltaTime;
        MoveAndRotateTowardsWaypoint();
    }

    private void SelectNextWaypoint()
    {
        _waypointID++;
    }

    private void MoveAndRotateTowardsWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint.position, _step);

        Vector3 targetDirection = _currentWaypoint.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, _step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Waypoint_Auto")
        {
            var distance = Vector3.Distance(transform.position, _currentWaypoint.position);
            if (distance < .1f)
            {
                //Debug.Log("Collided " + distance);            
                _areaMap = other.GetComponent<AreaMap>();

                if (_areaMap != null)
                {
                   // _availableWaypoints = _areaMap.HereIsTheInformationYouHaveRequested();
                    var randomTarget = Random.Range(0, _availableWaypoints.Length);
                    _currentWaypoint = _availableWaypoints[randomTarget];
                }
            }
        }
    }
}
