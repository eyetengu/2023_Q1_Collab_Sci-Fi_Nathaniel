using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FlyingVehicleBehavior : MonoBehaviour
{
    float _step;
    float _speed = 3f;
    float _speedMultiplier = 1f;



    void Start()
    {
        
    }


    void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;

        CheckUserInput();
        MoveFlyingVehicle();   
    }

    void CheckUserInput()
    {
        //SpeedBoost
        if(Input.GetKeyDown(KeyCode.LeftShift))        
            _speedMultiplier = 2f;
        else
            _speedMultiplier = 1f;


    }

    void MoveFlyingVehicle()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 direction = new Vector3(horizontalInput, mouseY, verticalInput) * Time.deltaTime;

        transform.Rotate(0, mouseX, 0);

        transform.Translate(direction);
    }
}
