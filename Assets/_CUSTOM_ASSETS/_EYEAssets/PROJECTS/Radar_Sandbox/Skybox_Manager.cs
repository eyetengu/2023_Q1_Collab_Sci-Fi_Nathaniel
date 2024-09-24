using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skybox_Manager : MonoBehaviour
{
    //SKYBOXES
    [SerializeField] Material[] _skyboxes;
    [SerializeField] bool _skyboxesUnlocked;

    int _skyboxID;

    bool _random;
    bool _selectNext = true;


//BUILT-IN FUNCTIONS
    void Start()
    {
        SelectSkyboxByID(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (_random) SelectRandomSkybox();
            else if(_selectNext) SelectNextSkybox();
        }
    }

//SKYBOX SELECTION FUNCTIONS
    void SelectRandomSkybox()
    {
        _skyboxID = Random.Range(0, _skyboxes.Length - 1);
        DisplaySkybox();
    }

    void SelectNextSkybox()
    {
        _skyboxID++;

        if (_skyboxID == 3) _skyboxesUnlocked = true;

        if (_skyboxID > _skyboxes.Length - 1)
        {
            if(_skyboxesUnlocked)
                _skyboxID = Random.Range(0, _skyboxes.Length - 1);
            else
                _skyboxID = 0;
        }

        DisplaySkybox();
    }

//EXTERNALLY-CALLED FUNCTIONS
    public void SelectSkyboxByID(int skyboxID)
    {
        _skyboxID = skyboxID;
        DisplaySkybox();
    }

//SKYBOX DISPLAY
    void DisplaySkybox()
    {
        RenderSettings.skybox = _skyboxes[_skyboxID];
    }

}
