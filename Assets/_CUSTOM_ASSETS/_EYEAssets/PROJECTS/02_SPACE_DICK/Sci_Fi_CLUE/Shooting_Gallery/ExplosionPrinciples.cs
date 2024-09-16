    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPrinciples : MonoBehaviour
{
    Rigidbody _rigidbody;

    [SerializeField] float _speedValue= 200;
    [SerializeField] float _jumpForce = 100;
    [SerializeField] float _rotationForce = 3.0f;   


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            //AddForceAtPosition_Cube();
            //AddForceMoveCube();
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }
    }

    private void FixedUpdate()
    {
        MoveObject();        
    }

    void AddForceAtPosition_Cube()
    {
        _rigidbody.AddForceAtPosition(new Vector3(0, _speedValue, 0), new Vector3(0, 25, 0), ForceMode.Force);
    }

    void AddForceMoveCube()
    {
        _rigidbody.AddForce(transform.forward * _speedValue, ForceMode.Force);
    }

    void MoveObject()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _rigidbody.AddForce(transform.forward * vertical * _speedValue, ForceMode.Acceleration);
        _rigidbody.AddRelativeTorque(Vector3.up * horizontal * _rotationForce, ForceMode.Impulse);
    }

    void PlayerJump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Force);
    }
}
