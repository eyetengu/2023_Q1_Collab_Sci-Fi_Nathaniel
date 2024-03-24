using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{
    [SerializeField] Material[] _skyboxOptions;
    int _skyboxIndex;

    void Start()
    {
        DisplayCurrentSkybox();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChooseNewSkybox();
    }

    void DisplayCurrentSkybox()
    {
        RenderSettings.skybox = _skyboxOptions[_skyboxIndex];
    }

    void ChooseNewSkybox()
    {
        _skyboxIndex++;

        if(_skyboxIndex > _skyboxOptions.Length-1) _skyboxIndex = 0;

        DisplayCurrentSkybox();
    }
}
