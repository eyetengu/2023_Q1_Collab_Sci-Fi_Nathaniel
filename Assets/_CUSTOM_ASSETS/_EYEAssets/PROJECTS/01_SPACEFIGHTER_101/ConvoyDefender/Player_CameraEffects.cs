using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CameraEffects : MonoBehaviour, INoiseReceiver
{
    Camera_Manager_CDEND _cameraManager;
    [SerializeField] CinemachineVirtualCamera[] _vCamSelection;
    [SerializeField] int vCamID;
    [SerializeField] CinemachineVirtualCamera _groupIntroCam;
    CinemachineVirtualCamera _selectedCamera;

    void Start()
    {
        _cameraManager = FindObjectOfType<Camera_Manager_CDEND>();
    }

    public void EnableAsteroidFieldCameraNoise(float amplitudeIn, float frequencyIn)
    {
        _selectedCamera = _cameraManager.ReturnSelectedCamera();

        _selectedCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitudeIn;
        _selectedCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequencyIn;
    }
}
