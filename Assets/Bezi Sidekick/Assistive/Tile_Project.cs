using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Project : MonoBehaviour
{
    ///Let's begin with building the solution board
    ///The SB will be the creation and destination point for all tiles created.
    ///we will need two lists to compare.
    ///one list will be represented on the top and the other on the left
    ///re: the two lists- we need a method for 'creating' a character that has a vehicle of a particular color

    (string, string) vehicleOwner;
    string nameto;
    string vehiclesop;


    [SerializeField] List<string> _names;
    [SerializeField] List<string> _vehicles;

    private void Start()
    {
        CreateVehicleOwnership();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }

    void CreateVehicleOwnership()
    {
        //in this class we will assign ownership and attributes to objects to define them for the game round
        //information will be distributed according amongst the objects and they will be evaluated based upon that information.





        foreach(var person in _names)
        {
            foreach(var vehicle in _vehicles)
            {
                vehicleOwner = (person, vehicle);
                Debug.Log(vehicleOwner);
            }
        }
    }





}
