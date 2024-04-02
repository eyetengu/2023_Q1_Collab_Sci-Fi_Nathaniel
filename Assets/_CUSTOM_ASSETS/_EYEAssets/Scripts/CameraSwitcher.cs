using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] cameras;
    private int _cameraID;
    private ResourceCollectionUI _uiManager;



    void Start()
    {
        _uiManager= GameObject.FindObjectOfType<ResourceCollectionUI>();

        ResetCameras();
        EngageCurrentCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            PreviousCamera();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            NextCamera();
        }
    }

    private void NextCamera()
    {
        _cameraID++;

        if(_cameraID > cameras.Length-1)
        {
            _cameraID= 0;
        }
        foreach (var cam in cameras)
        {
            cam.m_Priority = 10;
        }
        ResetCameras();
        EngageCurrentCamera();
        DisplayCurrentCameraName();
    }

    private void PreviousCamera()
    {
        _cameraID--;

        if(_cameraID < 0)
        {
            _cameraID = cameras.Length - 1;
        }
        ResetCameras();
        EngageCurrentCamera();
        DisplayCurrentCameraName();
    }

    private void ResetCameras()
    {
        foreach (var cam in cameras)
        {
            cam.m_Priority = 10;
        }
    }

    private void EngageCurrentCamera()
    {
        cameras[_cameraID].m_Priority = 50;
    }

    private void DisplayCurrentCameraName()
    {
        _uiManager.UpdateCameraText(cameras[_cameraID].name);

    }
}
