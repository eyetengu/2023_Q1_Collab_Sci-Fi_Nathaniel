using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LunarRacer : MonoBehaviour
{
    Rigidbody _rigidbody;

    [SerializeField] float _speed = 3.0f;
    [SerializeField] float _rotationSpeed = 300.0f;

    float _speedMultiplier = 1.0f;

    float _step;
    float _rotationStep;


//BUILT-IN FUNCTIONS
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();    
    }

    private void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;
        _rotationStep = _rotationSpeed * _speedMultiplier * Time.deltaTime;        

        if(transform.position.y < 0)
        { transform.position = new Vector3(transform.position.x, 0, transform.position.z); }
    }

    void FixedUpdate()
    {
        //UserInput();
        PlayerInput();
    }


//CORE FUNCTIONS
    void UserInput()
    {
        //if(Input.GetKeyDown(KeyCode.Space)) { }
    }

    void PlayerInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //_rigidbody.AddTorque((transform.up * horizontalInput * _rotationStep ),ForceMode.Force);

        transform.Rotate(0, horizontalInput * _rotationStep, 0);
        _rigidbody.AddForce ((transform.forward * verticalInput * _step), ForceMode.Acceleration);
    }
}
