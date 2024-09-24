using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower_Interfaces : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] Vector3 playerOffset;



    void Start()
    {
        
    }


    void Update()
    {
        transform.position = _playerTransform.position + playerOffset;
    }



}
