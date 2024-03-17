using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_WaypointTraveller : MonoBehaviour
{
    NavMeshAgent _agent;
    Rigidbody _rb;

    [SerializeField] private Transform[] _roomWaypoints;
    int _waypointID;
    Transform _currentWaypoint;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(ChooseNextTimer());
        _currentWaypoint = _roomWaypoints[_waypointID];
    }

    private void Update()
    {
        Debug.Log("Warping");
        //_agent.SetDestination(_currentWaypoint.position);
//        _agent.Move(_currentWaypoint.position);
        _agent.Warp(_currentWaypoint.position);
    }

    void ChooseNextWaypoint()
    {
        _waypointID++;

        if(_waypointID > _roomWaypoints.Length-1)
        {
            _waypointID = 0;
        }
        _currentWaypoint = _roomWaypoints[_waypointID];
        StartCoroutine(ChooseNextTimer());
    }

    IEnumerator ChooseNextTimer()
    {
        yield return new WaitForSeconds(2);
        ChooseNextWaypoint();
    }







}
