using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_DirectorsChair : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] Vector3 _cameraOffset = Vector3.zero;
    [SerializeField] Vector3 _cameraRotation = Vector3.zero;


    void Start()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    void Update()
    {
        transform.position = _playerTransform.position + _cameraOffset ;
        transform.rotation = Quaternion.Euler(_cameraRotation);
    }
}
