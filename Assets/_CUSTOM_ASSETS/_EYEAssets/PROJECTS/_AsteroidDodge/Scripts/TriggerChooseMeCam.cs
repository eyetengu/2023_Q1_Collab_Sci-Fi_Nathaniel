using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChooseMeCam : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _associatedVCam;
        
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            _associatedVCam.m_Priority= 65;        
        Debug.Log(other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")        
            _associatedVCam.m_Priority = 10;        
    }

}
