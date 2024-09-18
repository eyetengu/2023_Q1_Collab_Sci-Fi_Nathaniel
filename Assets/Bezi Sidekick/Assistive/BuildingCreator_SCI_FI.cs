using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BuildingCreator_SCI_FI : MonoBehaviour
{    
    [Header("SCI-FI BUILDING COMPONENTS")]
    [SerializeField] List<GameObject> _lowerLevelsSciFi;
    [SerializeField] List<GameObject> _upperLevelsSciFi;
    [SerializeField] List<GameObject> _topLevelsSciFi;
    [SerializeField] List<GameObject> _specialtyShop;
    [SerializeField] List<GameObject> _tallSections;

    [Header("BUILDING SPECS")]
    [SerializeField] float _buildingHeight = 3.0f;

    [Header("CONDITIONS")]
    [SerializeField] bool _single;
    [SerializeField] bool _double;
    [SerializeField] bool _triple;

    [SerializeField] List<GameObject> _sciFiBuildings;
    GameObject _currentBuilding;


//BUILT-IN FUNCTIONS
    void Start()
    {
        CreateACustomBuilding();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) CreateACustomBuilding();
        if (Input.GetKeyDown(KeyCode.U)) SaveBuildingToList();
    }


//BUILT-IN FUNCTIONS
    void CreateACustomBuilding()
    {
        GameObject singleStory = _lowerLevelsSciFi[Random.Range(0, _lowerLevelsSciFi.Count - 1)]; 
        GameObject doubleStory = _upperLevelsSciFi[Random.Range(0, _upperLevelsSciFi.Count - 1)];
        GameObject trebleStory = _topLevelsSciFi[Random.Range(0, _topLevelsSciFi.Count - 1)];
                
        var singletime = Instantiate(singleStory, transform.position, Quaternion.identity);

        if (_double)
        {
            var doubletime = Instantiate(doubleStory, transform.position + new Vector3(0, _buildingHeight, 0), Quaternion.identity);

            if (_triple)
            {
                var trebletime = Instantiate(trebleStory, transform.position + new Vector3(0, _buildingHeight * 2, 0), Quaternion.identity);
                trebletime.transform.SetParent(singletime.transform);
            }
        }
        _currentBuilding = singletime.gameObject;    
    }

    void CreateATallBuilding()
    {
        Instantiate(_tallSections[Random.Range(0, _tallSections.Count - 1)], transform.position, Quaternion.identity);
    }

    
//SAVE BUILDING TO LIST
    void SaveBuildingToList()
    {
        _sciFiBuildings.Add(_currentBuilding);
    }


//CLEAR BUILDING
    void ClearCurrentBuilding()
    {
        Destroy(_currentBuilding);
    }


    //This script is to become a building creator / building placer
    //On one hand it will create custom buildings from prefab parts
    //On the other hand, we will place our buildings in the scene
    //ideally, the buildings would be lining the streets and facing them as well.


    ///PART I- BUILDING CREATION
    ///Create Single Story Buildings
    ///Create Double Story Buildings
    ///Create Treble Story Buildings
    ///Create Tall Buildings
    ///Create Custom Buildings (Interactions)
    ///
    ///musings: When we create the scene, how do we do it? do we create a city block and place it?
    ///do we run two street facings(buildings) and remove to allow for the road?
    ///do we lay the road first and anywhere the road is, the buildings are not allowed to be?
    ///

}
