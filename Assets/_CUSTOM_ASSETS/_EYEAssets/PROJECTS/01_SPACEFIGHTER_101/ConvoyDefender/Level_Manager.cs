using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    [SerializeField] GameObject[] _levelBackgrounds;
    int _levelID;
    Skybox_Manager _skyboxManager;


    void Start()
    {
        _skyboxManager = FindObjectOfType<Skybox_Manager>();
        ResetAndShow();        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SelectAndShowNextLevel();            
        }        
    }


//COMPLEX FUNCTIONS
    void ResetAndShow()
    {
        ResetAllLevels();
        ShowSelectedLevel();
    }

    void SelectAndShowNextLevel()
    {
        NextLevel();
        ShowSelectedLevel();
    }


//BASIC FUNCTIONS
    void ResetAllLevels()
    {
        foreach(var level in _levelBackgrounds)
        {
            level.SetActive(false);
        }
    }

    void ShowSelectedLevel()
    {
        _skyboxManager.SelectSkyboxByID(_levelID);
        _levelBackgrounds[_levelID].SetActive(true);
    }

    void NextLevel() 
    {         
        _levelID++;

        if (_levelID >= _levelBackgrounds.Length)
            _levelID = 0;

        _levelBackgrounds[_levelID].SetActive(true);        
    }
}
