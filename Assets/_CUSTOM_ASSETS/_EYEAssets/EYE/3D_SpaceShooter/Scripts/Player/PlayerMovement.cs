using Cinemachine.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
    : MonoBehaviour
{
    float _step;
    [SerializeField] float _speed = 5f;
    float _speedMultiplier = 1f;
    [SerializeField] float maxXMovement = 18;
    [SerializeField] float maxZMovement = -10;


    void FixedUpdate()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;

        UserInput();
        Player_movement();
        PlayerBoundingBoxValues();
    }

    void UserInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
             _speedMultiplier = 3;
            Debug.Log("Speed: " + _speedMultiplier); 
        }
        else
            _speedMultiplier = 1;
    }

    void Player_movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        transform.position += direction * _step;
    }

    void PlayerBoundingBoxValues()
    {
        //X Values
        if (transform.position.x >= maxXMovement)        
            transform.position = new Vector3(maxXMovement, transform.position.y, transform.position.z);        
        if (transform.position.x <= -maxXMovement)        
            transform.position = new Vector3(-maxXMovement, transform.position.y, transform.position.z);        

        //Z Values
        if(transform.position.z >= maxZMovement)
            transform.position = new Vector3(transform.position.x, transform.position.y, maxZMovement);
        if(transform.position.z <= -maxZMovement)
            transform.position = new Vector3(transform.position.x, transform.position.y, -maxZMovement);
    }
    
}


