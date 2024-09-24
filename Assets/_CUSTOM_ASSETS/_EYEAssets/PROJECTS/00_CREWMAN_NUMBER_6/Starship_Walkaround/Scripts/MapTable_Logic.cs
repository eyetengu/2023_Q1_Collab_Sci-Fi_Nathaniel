using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTable_Logic : MonoBehaviour
{
    [SerializeField] GameObject[] _stations;
    int _stationID;



    void Start()
    {
        ShowCurrentStation();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            ChangeStation();
        }        
    }

    void ChangeStation()
    {
        _stationID++;
        if (_stationID > _stations.Length - 1)
            _stationID = 0;

        ShowCurrentStation();
    }

    void ShowCurrentStation()
    {
        foreach (var station in _stations)
        {
            station.SetActive(false);
        }

        _stations[_stationID].SetActive(true);
    }

    

}
