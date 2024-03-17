using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomAsWaypoint : MonoBehaviour
{
    [SerializeField] private Transform[] _roomLocations;

    enum RoomRole
    {
        Repair,
        Command,
        Science,
        Medical,
        Flight,
        Harvest
    }

    RoomRole _currentRole = RoomRole.Repair;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
