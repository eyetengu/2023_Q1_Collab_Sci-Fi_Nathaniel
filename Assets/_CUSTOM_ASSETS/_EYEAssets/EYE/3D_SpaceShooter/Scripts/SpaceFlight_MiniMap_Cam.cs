using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFlight_MiniMap_Cam : MonoBehaviour
{
    Transform _target;



    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();    
    }

    void Update()
    {
        transform.position = new Vector3(_target.position.x, 25, _target.position.z);
    }
}
