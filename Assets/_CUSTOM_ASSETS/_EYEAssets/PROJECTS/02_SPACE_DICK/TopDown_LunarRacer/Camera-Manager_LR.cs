using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager_LR : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] _vCamSelection;
    int _vCamIndex = 0;
    CinemachineVirtualCamera _currentVirtualCamera;

    [SerializeField] CinemachineDollyCart _cart_Alpha_Flythrough;
    [SerializeField] float _flythroughSpeed = 5.0f;

    [SerializeField] CinemachineVirtualCamera _cam_Beta_Vanity;
    float _vanityTimer;
    float _vanityDelay = 3.0f;
    bool _vanityCamActive;
    bool _ortho;
    [SerializeField] float _vanityCamDelay = 3.0f;

//BUILT-IN FUNCTIONS
    void Start()
    {
        DisplayCurrentCamera();
        //SetVanityCamTimer();
    }

    void Update()
    {
        UserInput();
        VanityTimerCheck();
    }

    void UserInput()
    {
        if (Input.anyKey)        
            SetVanityCamTimer();

        if(Input.GetKeyDown(KeyCode.Alpha1))        
            SelectCurrentCamera();                  
        if (Input.GetKeyDown(KeyCode.Alpha2))
            AdjustCurrentCamera_Ortho();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeCameraFOV();
    }

//VANITY CAMERA CHECK
    void SetVanityCamTimer()
    {
        _cam_Beta_Vanity.m_Priority = 10;
        var _vanityTimer = Time.time + _vanityDelay;
    }

    void VanityTimerCheck()
    {

        if(Time.time == _vanityTimer)
        {
            _vanityCamActive = true;
            Debug.Log("Vanity Cam Active");
            StartCoroutine(VanityCamTimer());
        }
    }

//CORE FUNCTIONS
    void ActivateAndDisplayVCamByInt(int camID)
    {
        ResetAllVCameras();

        _currentVirtualCamera = _vCamSelection[camID];
        _currentVirtualCamera.m_Priority = 25;

        if (camID == 0)
            EnableFlyThroughCamera();
    }
    
    void AdjustCurrentCamera_Ortho()
    {
        _ortho = !_ortho;

        _currentVirtualCamera.m_Lens.Orthographic = _ortho;       
    }

    void DisplayCurrentCamera()
    {
        _currentVirtualCamera = _vCamSelection[_vCamIndex];
        Debug.Log("Current Camera: " + _currentVirtualCamera.name);

        ResetAllVCameras();

        _currentVirtualCamera.m_Priority = 25;
        
        if (_vCamIndex == 0)
            EnableFlyThroughCamera();
    }

    void ResetAllVCameras()
    {
        foreach (var vcam in _vCamSelection)
            vcam.m_Priority = 10;
    }


//FLYTHROUGH CAMERA
    void EnableFlyThroughCamera()
    {
        _cart_Alpha_Flythrough.m_Speed = _flythroughSpeed;
        _cart_Alpha_Flythrough.m_Position = 0;
    }


//CHANGE CURRENT CAMERA FIELD OF VIEW
    void ChangeCameraFOV()
    {
        _currentVirtualCamera.m_Lens.FieldOfView += 60;
        if (_currentVirtualCamera.m_Lens.FieldOfView > 180)
            _currentVirtualCamera.m_Lens.FieldOfView = 30;
    }


//VANITY CAMERA
    IEnumerator VanityCamTimer()
    {
        yield return new WaitForSeconds(_vanityCamDelay);
        ActivatePlayerVanityCam();
        _vanityCamActive = false;
    }

    void SelectCurrentCamera()
    {
        _vCamIndex++;

        if (_vCamIndex > _vCamSelection.Length - 1)
            _vCamIndex = 0;

        _currentVirtualCamera = _vCamSelection[_vCamIndex];

        DisplayCurrentCamera();
    }

    void ActivatePlayerVanityCam()
    {
        Debug.Log("Vanity Cam Displaying");
        _cam_Beta_Vanity.m_Priority = 45;
    }
}
