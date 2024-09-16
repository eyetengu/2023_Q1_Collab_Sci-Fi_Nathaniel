using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager_CDEND : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] _vCamSelection;
    [SerializeField] int vCamID;
    [SerializeField] CinemachineVirtualCamera _groupIntroCam;
    CinemachineVirtualCamera _selectedCamera;
    CinemachineBasicMultiChannelPerlin _selectedNoise;

    //BUILT-IN FUNCTIONS
    void Start()
    {
        ResetAllVCams();
        DisplaySelectedVCam();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))        
            ResetCameraOperation();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            ResetCameraNoise();
    }


//CORE FUNCTIONS
    public void ResetCameraOperation()
    {
        Debug.LogWarningFormat("Resetting Camera");
        ResetAllVCams();
        SelectNextVirtualCamera();
        DisplaySelectedVCam();
    }

    public void EnableGroupIntroCamera()
    {
        ResetAllVCams();
        _groupIntroCam.m_Priority = 25;
    }

    public void EnableGameCamera()
    {
        ResetAllVCams();
        _vCamSelection[0].m_Priority = 25;        
    }


//BASIC FUNCTIONS
    void ResetAllVCams()
    {
        //Debug.Log("Resetting All VCAMS");
        foreach (var cam in _vCamSelection)
            cam.m_Priority = 10;
    }

    void SelectNextVirtualCamera()
    {
        Debug.Log("Selecting Next");
        vCamID++;
        
        if (vCamID > _vCamSelection.Length - 1)
            vCamID = 0;
    }

    void DisplaySelectedVCam() 
    {
        //Debug.Log("Selecting Next VCAM");
        _selectedCamera = _vCamSelection[vCamID];
        _selectedCamera.m_Priority = 25;
    }

    public CinemachineVirtualCamera ReturnSelectedCamera()
    {        
        return _selectedCamera;
    }


//POST_PROCESSING
    void ResetCameraNoise()
    {
        _selectedNoise = _selectedCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        
        float _selectedAmplitude = _selectedNoise.m_AmplitudeGain;
        float _selectedFrequency = _selectedNoise.m_FrequencyGain;

        _selectedAmplitude = 0;
        _selectedFrequency = 0;
    }

    void SetCameraNoise(float amplitude, float frequency)
    {
        _selectedNoise = _selectedCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        float _selectedAmplitude = _selectedNoise.m_AmplitudeGain;
        float _selectedFrequency = _selectedNoise.m_FrequencyGain;

        _selectedAmplitude = amplitude;
        _selectedFrequency = frequency;
    }

}
