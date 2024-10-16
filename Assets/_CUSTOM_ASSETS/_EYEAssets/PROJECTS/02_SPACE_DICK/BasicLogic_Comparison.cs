using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasicLogic_Comparison : MonoBehaviour
{
    [SerializeField] string[] _names;
    [SerializeField] string[] _vehicles;

    [SerializeField] TMP_Text _nameField;
    [SerializeField] TMP_Text _vehicleField;


    void Start()
    {
        InitializeLists();
    }


    void InitializeLists()
    {
        string listOfNames = "";
        foreach (var item in _names)
        {
            listOfNames += item + "\n";
        }
        _nameField.text = listOfNames;

        string listOfVehicles = "";
        foreach(var item in _vehicles)
        {
            listOfVehicles += item + "\n";
        }
        _vehicleField.text = listOfVehicles;
    }

    void Update()
    {
        
    }












}
