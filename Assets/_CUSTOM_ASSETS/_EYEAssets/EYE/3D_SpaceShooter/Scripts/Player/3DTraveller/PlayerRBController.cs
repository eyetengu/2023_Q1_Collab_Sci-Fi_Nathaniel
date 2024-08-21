using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRBController : MonoBehaviour
{
    Rigidbody _rb;
    CharacterController _controller;

    float _step;
    float _rotationStep;
    [SerializeField] float _speed = 3.0f;
    [SerializeField] float _rotationSpeed = 1500.0f;
    float _speedMultiplier = 1.0f;
    
        
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible= false;

        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;
        _rotationStep = _rotationSpeed * Time.deltaTime;    

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None; 
            Cursor.visible = true;
        }

        if(Input.GetKeyDown(KeyCode.W))        
            _speed += 0.2f;
        
        if (Input.GetKeyDown(KeyCode.S))
            _speed -= 0.2f;

        PlayerMover();
    }

    void PlayerMover()
    {
        float verticalInput = Input.GetAxis("Vertical");        //W & S keys
        float horizontalInput = Input.GetAxis("Horizontal");    //A & D keys
        float barrelRoll = Input.GetAxis("BarrelRoll");         //X & E keys
        //float mousex = Input.GetAxis("Mouse X");
        float mousey = Input.GetAxis("Mouse Y");                //Mouse Y

        var stepMultiplier = _step * verticalInput;

        var moveDirection = new Vector3(mousey * (_rotationStep/2), horizontalInput  * _rotationStep/2, -barrelRoll * _rotationStep);
        _rb.AddTorque(moveDirection);
        transform.Rotate(moveDirection);

        //Speed
        Debug.Log("Velocity: " + _rb.velocity.magnitude);

        while(_rb.velocity.magnitude <= 12 && _rb.velocity.magnitude >= -12)
        {
            //_rb.AddRelativeForce(transform.forward *  verticalInput * _step); // stepMultiplier);
            _rb.AddRelativeForce(0, 0, 1 * _step * 1000 * verticalInput, ForceMode.Impulse);
            return; 
        }

        /*
        if(_rb.velocity.magnitude >= 12)
            _rb.velocity = new Vector3(0, 0, 12);
        if (_rb.velocity.magnitude <= -12)
            _rb.velocity = new Vector3(0, 0, -12);
        */
    }

}
