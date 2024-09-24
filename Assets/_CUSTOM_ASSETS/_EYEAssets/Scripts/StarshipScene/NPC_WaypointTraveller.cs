using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_WaypointTraveller : MonoBehaviour
{
    //NavMeshAgent _agent;
    Rigidbody _rb;

    [SerializeField] private Transform[] _roomWaypoints;
    int _waypointID;
    Transform _currentWaypoint;
    [SerializeField] bool _warping;
    [SerializeField] bool _isLooping;
    [SerializeField] bool _isMovingForward;
    [SerializeField] bool _randomRoute;



    private void Start()
    {
        //_agent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(ChooseNextTimer());
        _currentWaypoint = _roomWaypoints[_waypointID];
    }

    private void Update()
    {
        //if(_agent.isOnNavMesh==false)
            //Debug.Log("NONAVMESH");

        if (_warping)
        {
            Debug.Log("Warping");
            //_agent.Warp(_currentWaypoint.position);
        }
        else
        {
            //_agent.SetDestination(_currentWaypoint.position);
            //_agent.Move(_currentWaypoint.position);

        }

        //if(_agent.remainingDistance < .15f)
        //{
            //StartCoroutine(FaceStationTimer());
        //}
    }

    void ChooseNextWaypoint()
    {

        if (_randomRoute)
        {
            _waypointID = Random.Range(0, _roomWaypoints.Length - 1);
        }
        else
        {
            if (_isMovingForward)
                _waypointID++;
            else
                _waypointID--;

            if (_isLooping)
            {
                if (_isMovingForward)
                {
                    if (_waypointID > _roomWaypoints.Length - 1)
                        _waypointID = 0;
                }
                else
                {
                    if (_waypointID < 0)
                        _waypointID = _roomWaypoints.Length - 1;
                }
            }
            else if (_isLooping == false)
            {
                if (_isMovingForward)
                {
                    if (_waypointID > _roomWaypoints.Length - 1)
                    {
                        _waypointID = _roomWaypoints.Length - 2;
                        _isMovingForward = false;
                    }
                }
                else if (_isMovingForward == false)
                {
                    if (_waypointID < 0)
                    {
                        _waypointID = 1;
                        _isMovingForward = true;
                    }
                }
            }
        }

        _currentWaypoint = _roomWaypoints[_waypointID];
        StartCoroutine(ChooseNextTimer());
    }

    IEnumerator ChooseNextTimer()
    {
        yield return new WaitForSeconds(2);
        ChooseNextWaypoint();
    }


    IEnumerator FaceStationTimer()
    {
        //turn to face direction of waypoint
        transform.rotation = _currentWaypoint.rotation;
        yield return new WaitForSeconds(2.0f);

    }




}
