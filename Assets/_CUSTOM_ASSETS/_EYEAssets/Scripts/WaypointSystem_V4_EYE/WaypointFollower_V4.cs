using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower_V4 : MonoBehaviour
{
    public enum NPCRole
    {
        None, 
        Command, 
        Repair, 
        Clean, 
        Medical, 
        Science, 
        Hangar
    }

    [Header("Room & Rank Qualifiers")]
    public NPCRole _currentRole;
    [SerializeField] bool _roleMatch;
    [SerializeField] bool _isPerformingChore;

    [Header("Follow Conditions")]
    bool _isRandom;
    bool _isFollowingForward;
    bool _followInReverse;
    bool _isLooping;

    [Header("Speed Variables")]
    [SerializeField] float _speed = 3;
    float _speedMultiplier = 1f;
    float _step;

    [Header("Waypoints")]
    [SerializeField]
    int _waypointID;
    [SerializeField] Transform[] _waypoints;
    Transform _currentWaypoint;

    int _choreID;
    [SerializeField] Transform[] _waypointZones;
    Transform _currentWorkZone;
    int _workActions;
    float _choreTimer = 3;


    void Start()
    {
        _currentWaypoint = _waypoints[_waypointID];                
    }

    void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;

        if (_roleMatch)
        {
            if (_waypointZones != null)
                PerformRoomDuties();
            else
            {
                _roleMatch = false;
            }
        }
        else
        {
            MoveToCurrentWaypoint();
            DistanceChecker();
        }
    }

    //Standard Waypoint Follower
    void MoveToCurrentWaypoint()
    {
        if (_currentWaypoint == null)
            SelectNextWaypoint();

        transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint.position, _step);
    }

    void DistanceChecker()
    {
        float distance = Vector3.Distance(transform.position, _currentWaypoint.position);
        
        if(distance < .2f)
        {
            if(_isRandom)
                ChooseRandomWaypoint();
            else
            {
                if (_roleMatch)
                    if(_waypointZones != null)
                        SelectNextWorkzone();
                else
                    SelectNextWaypoint();
            }
        }
    }

    void ChooseRandomWaypoint()
    {
        _currentWaypoint = _waypoints[Random.Range(0, _waypoints.Length-1)  ];
    }

    void SelectNextWaypoint()
    {
        Debug.Log("SelectNextWaypoint()");
        if (_isRandom)
            ChooseRandomWaypoint();
        else
        {
            if (_isFollowingForward)
            { 
                _waypointID++;
                
                if (_waypointID > _waypoints.Length-1)
                {
                    if (_isLooping)
                        _waypointID = 0;
                    else
                    {
                        _waypointID = _waypoints.Length - 2;
                        _isFollowingForward = false;
                    }
                }
            }
            else
            {
                _waypointID--;
                if (_waypointID < 0)
                {
                    if (_isLooping)
                        _waypointID = _waypoints.Length - 1;
                    else
                    {
                        _waypointID = 1;
                        _isFollowingForward = true;
                    }
                }
            }
            _currentWaypoint = _waypoints[_waypointID];
        }
    }
   
    //Room Waypoints & Duties
    void PerformRoomDuties()
    {
        if(_isPerformingChore == false)
        {
            Debug.Log("No Chore Performed");
            _isPerformingChore = true;
            SelectNextWorkzone();
            StartCoroutine(WorkspaceTimer());
        }
        var distance = Vector3.Distance(transform.position, _currentWaypoint.position);
        if(distance > .2f)
            transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint.position, _step);
    }

    void SelectNextWorkzone()
    {
        _workActions++;
        Debug.Log("Work Action: " + _workActions);
        if (_workActions >= 3)
        {
            _roleMatch = false;
            SelectNextWaypoint();
        }
        else if (_workActions > 1)
        {
            var randomPoint = RandomWorkZone();
            if (randomPoint == _waypointID)
                RandomWorkZone();
            else
                _currentWaypoint = _waypointZones[randomPoint];
        }
        else
        {
            if (_waypointZones != null)
            {
                var randomPoint = RandomWorkZone();
                _currentWaypoint = _waypointZones[randomPoint];
            }
            else
            {
                _roleMatch = false; 
            }
        }
    }

    int RandomWorkZone()
    {
        var randomWaypoint = Random.Range(0, _waypointZones.Length - 1);

        return randomWaypoint;
    }

    IEnumerator WorkspaceTimer()
    {
        Debug.Log("Entering the Workspace Timer");
        yield return new WaitForSeconds(_choreTimer);
        _isPerformingChore = false;
        Debug.Log("Exiting the Workspace Timer");
        //SelectNextWorkzone();
    }    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(_currentRole);// + " " + roomRole);
        if(other.tag == "LocationStation")
        {
            var waypointScript = other.GetComponent<RoomWaypoint>();

            if(waypointScript != null)
            {
                Debug.Log("Obtaining Room Data");

                _choreID = 0;
                _workActions = 0;

                var roomRole = waypointScript._thisRoomsRole;
                if (_currentRole.ToString() == roomRole.ToString())
                {
                    _waypointZones = waypointScript._workZones;
                    _roleMatch= true;
                    Debug.Log("Performing Rank Appropriate Duty");
                }
            }
        }
    }

}
