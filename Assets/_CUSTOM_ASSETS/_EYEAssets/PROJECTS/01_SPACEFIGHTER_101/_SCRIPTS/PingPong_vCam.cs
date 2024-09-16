using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong_vCam : MonoBehaviour
{
    [SerializeField] CinemachineDollyCart _dolly;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _dolly = other.GetComponent<CinemachineDollyCart>();
        if(_dolly != null)
        {
            _dolly.m_Speed *= -1;
        }
    }
}
