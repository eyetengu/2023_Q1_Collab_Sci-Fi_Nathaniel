using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;


//Require Rigidbody
//Require CharacterController
public class Basic_Player_Walking : MonoBehaviour
{
    Rigidbody _rb;

    [Header("SPEED VALUES")]
    [SerializeField] float _speed = 3.0f;
    [SerializeField] float _rotationSpeed = 5.0f;

    float _speedMultiplier = 1.0f;
    float _step;
    float _rotationStep;

    CharacterController _controller;
    float _gravity = -9.81f;
    float _yDirection;
    float _jumpPower;
    float _totalSpeed;


//BUILT-IN FUNCTIONS
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;
        _rotationStep = _rotationSpeed * Time.deltaTime;

        MovePlayer();
        
        if (Input.GetKey(KeyCode.LeftShift))
            _speedMultiplier = 2.0f;
        else
            _speedMultiplier = 1.0f;
    }


//CORE FUNCTIONS
    void MovePlayer()
    {
        float hMovement = Input.GetAxis("Horizontal");
        float vMovement = Input.GetAxis("Vertical");
        float yRotation = Input.GetAxis("Mouse X");
        //use this commented code to rotate an fps camera on its x axis
        //float xRotation = Input.GetAxis("Mouse Y");

        

        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.y += yRotation * _rotationSpeed;
        //rotation.x += xRotation * _rotationSpeed;
        transform.rotation = Quaternion.Euler(rotation);

        Vector3 direction = new Vector3(hMovement, 0, vMovement);
        direction = transform.TransformDirection(direction);

        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yDirection = _jumpPower;
            }
        }
        else
        {
            Debug.Log("Player Is Not Grounded");
            _yDirection -= _gravity * Time.deltaTime;
        }
        direction.y = _yDirection;

        Debug.Log($"Speed {_totalSpeed} Direction: {direction}  ");
        _controller.Move(direction * _totalSpeed);

    }
}
