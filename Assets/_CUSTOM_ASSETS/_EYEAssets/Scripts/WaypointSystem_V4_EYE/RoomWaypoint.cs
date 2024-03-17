using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWaypoint : MonoBehaviour
{
    public Transform[] _workZones;
    int _workZoneID;
    Transform _currentWorkZone;

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

    public NPCRole _thisRoomsRole;

}
