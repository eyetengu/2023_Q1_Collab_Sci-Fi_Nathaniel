using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandbox_EnemyType_Appearance : MonoBehaviour
{
    Sandbox_Enemy_Appearance _paintJob;

    [SerializeField] GameObject[] _vehicleTypes;
    int _typeID;
    GameObject _currentVehicle;

    MeshRenderer _renderer;    

    [SerializeField] bool _fighter, _heavyFighter, _larger, _stillBigger;
    bool _selectRandom;


    void Start()
    {
        _paintJob = GetComponent<Sandbox_Enemy_Appearance>();

        HideAllVehicles();
        ShowCurrentVehicle();
    }

    void Update()
    {
        UserInput();
    }

    void UserInput()
    {
        if      (Input.GetKeyDown(KeyCode.Alpha1) && _fighter)        
            SelectAndShowNextVehicle();        

        else if (Input.GetKeyDown(KeyCode.Alpha2) && _heavyFighter)        
            SelectAndShowNextVehicle();        

        else if (Input.GetKeyDown(KeyCode.Alpha3) && _larger)        
            SelectAndShowNextVehicle();        

        else if (Input.GetKeyDown(KeyCode.Alpha4) && _stillBigger)        
            SelectAndShowNextVehicle();
    }

    void SelectAndShowNextVehicle()
    {
        if (_selectRandom)
            SelectRandomVehicle();
        else
        {
            HideAllVehicles();
            SelectNextVehicle();
            ShowCurrentVehicle();
        }
        _paintJob.ShowCurrentPaintColor();
    }

//----------------------------------------------
//Core Scripts
    void HideAllVehicles()
    {
        foreach(var type in _vehicleTypes)        
            type.SetActive(false);        
    }

    void SelectNextVehicle()
    {
        _typeID++;
        if (_typeID > _vehicleTypes.Length - 1)
            _typeID = 0;
    }
    void SelectRandomVehicle()
    {
        _typeID = Random.Range(0, _vehicleTypes.Length - 1);
    }

    void ShowCurrentVehicle()
    {
        _currentVehicle = _vehicleTypes[_typeID];
        _currentVehicle.SetActive(true);
    }




}
