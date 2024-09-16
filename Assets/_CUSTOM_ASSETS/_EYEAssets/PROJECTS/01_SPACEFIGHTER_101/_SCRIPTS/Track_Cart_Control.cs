using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track_Cart_Control : MonoBehaviour
{
    [SerializeField] CinemachineDollyCart _dolly;
    float _step;
    [SerializeField] float _speed = 1f;


    void Start()
    {
        
    }


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        _step = horizontal * _speed * Time.deltaTime;
        _dolly.m_Speed += _step;
    }
}
