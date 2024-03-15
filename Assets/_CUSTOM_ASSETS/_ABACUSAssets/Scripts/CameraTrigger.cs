using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject cinemachineVirtualCamera;
    private CinemachineVirtualCamera virtualCamera;
    void Awake()
    {
        virtualCamera = cinemachineVirtualCamera.GetComponent<CinemachineVirtualCamera>();
        if (virtualCamera == null) Debug.LogError("A component cinemachineVirtualCamera is missing\n");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player triggered camera change");
            virtualCamera.Priority = 1;
        }
    }
}
