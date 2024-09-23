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

    [SerializeField] List<Material> _paintJobs;

    [Header("BUILDING SPECS")]
    [SerializeField] float _buildingHeight = 3.0f;

    [Header("CONDITIONS")]
    [SerializeField] bool _single;
    [SerializeField] bool _double;
    [SerializeField] bool _triple;

    [SerializeField] List<GameObject> _sciFiBuildings;
    GameObject _currentBuilding;
    int _paintID;
    GameObject _singleStory;
    GameObject _doubleStory;
    GameObject _trebleStory;


//BUILT-IN FUNCTIONS
    void Start()
    {
        //CreateACustomBuilding();
        CreateCityBlock();
    }

    void Update()
    {
        //if (Input.anyKey) ClearCurrentBuilding();
        if (Input.GetKeyDown(KeyCode.P))
        {
            ClearCurrentBuilding();
            CreateACustomBuilding();
            ChangePaintJob();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            ClearCurrentBuilding();
            CreateATallBuilding();
            ChangePaintJob();
        }

        if (Input.GetKeyDown(KeyCode.U)) SaveBuildingToList();
    }


//BUILT-IN FUNCTIONS
    void CreateACustomBuilding()
    {
        _singleStory = _lowerLevelsSciFi[Random.Range(0, _lowerLevelsSciFi.Count - 1)]; 
        _doubleStory = _upperLevelsSciFi[Random.Range(0, _upperLevelsSciFi.Count - 1)];
        _trebleStory = _topLevelsSciFi[Random.Range(0, _topLevelsSciFi.Count - 1)];
                
        var storySingle = Instantiate(_singleStory, transform.position, Quaternion.identity);

        if (_double)
        {
            var storyDouble = Instantiate(_doubleStory, storySingle.transform.position + new Vector3(0, _buildingHeight, 0), Quaternion.identity);
            storyDouble.transform.SetParent(storySingle.transform);

            if (_triple)
            {
                if (_trebleStory == _topLevelsSciFi[0] || _trebleStory == _topLevelsSciFi[1])
                { 
                    GameObject storyTreble = Instantiate(_trebleStory, storyDouble.transform.position + new Vector3(-2.5f, _buildingHeight, -2.5f), Quaternion.identity); 
                    storyTreble.transform.SetParent(storyDouble.transform);
                }
                else
                {
                    GameObject storyTreble = Instantiate(_trebleStory, storyDouble.transform.position + new Vector3(0, _buildingHeight, 0), Quaternion.identity);
                    storyTreble.transform.SetParent(storyDouble.transform);
                }
            }
        }
        ChangePaintJob();
        _currentBuilding = storySingle.gameObject;    
    }

    void CreateATallBuilding()
    {
        _currentBuilding = Instantiate(_tallSections[Random.Range(0, _tallSections.Count - 1)], transform.position, Quaternion.identity);
    }

    void ChangePaintJob()
    {
        _paintID++;
        if (_paintID > _paintJobs.Count - 1)
            _paintID = 0;

        if (_singleStory != null)
            _singleStory.GetComponent<MeshRenderer>().material = _paintJobs[_paintID];
        if (_doubleStory != null)
            _doubleStory.GetComponent<MeshRenderer>().material = _paintJobs[_paintID];
        if (_trebleStory != null)
            _trebleStory.GetComponent<MeshRenderer>().material = _paintJobs[_paintID];
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




    ///create city block routine
    ///
    [SerializeField] int _cityBlockWidth;
    [SerializeField] int _cityBlockLength;
    int _placementPointX;
    int _placementPointY;


    void CreateCityBlock()
    {
        _placementPointY = 0;
        for (int column = 0; column < _cityBlockWidth; column++)
        {
            //_placementPointX = 0;
            _placementPointY = 0;
            for (int row = 0; row < 1; row++)
            {
                CreateACustomBuilding();
                _currentBuilding.transform.position += new Vector3(_placementPointX, 0, _placementPointY);
                _placementPointX += 10;
                _placementPointY += 10;
                //create a building
                //place building at point
                //adjust next buildings placement point
                if (column == 0)
                    _currentBuilding.transform.rotation = Quaternion.Euler(0, -90, 0);
                else
                    _currentBuilding.transform.rotation = Quaternion.Euler(0, 90, 0);
            }            
            _placementPointX = 10;
            _placementPointY = -10;
        }

    }

}
