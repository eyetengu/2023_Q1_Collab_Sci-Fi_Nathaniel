using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RB_PlayerMover : MonoBehaviour
{
    Rigidbody _rb;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            
            _rb.AddForce(transform.forward, ForceMode.VelocityChange);
        }
    }
}
