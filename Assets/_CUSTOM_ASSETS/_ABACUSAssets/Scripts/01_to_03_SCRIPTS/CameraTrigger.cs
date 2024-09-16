using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject CMVirtualCameraNext;
    public GameObject CMVirtualCameraPrevious;
    private CinemachineVirtualCamera virtualCameraNext;
    private CinemachineVirtualCamera virtualCameraPrevious;
    void Awake()
    {
        virtualCameraNext = CMVirtualCameraNext.GetComponent<CinemachineVirtualCamera>();
        if (virtualCameraNext == null) Debug.LogError("A component cinemachineVirtualCamera is missing\n");
        virtualCameraPrevious = CMVirtualCameraPrevious.GetComponent<CinemachineVirtualCamera>();
        if (virtualCameraPrevious == null) Debug.LogError("A component cinemachineVirtualCamera is missing\n");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player triggered camera change");
            virtualCameraNext.Priority = 3;
            virtualCameraPrevious.Priority = 1;
        }
    }
}
