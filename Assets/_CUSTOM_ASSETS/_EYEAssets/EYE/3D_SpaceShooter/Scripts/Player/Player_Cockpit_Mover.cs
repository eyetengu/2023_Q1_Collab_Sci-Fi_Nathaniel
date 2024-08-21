using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Cockpit_Mover : MonoBehaviour
{
    float _step;
    [SerializeField] private float _speed = 4f;
    private float _speedMultiplier = 1f;
    
    
    void Start()
    {
        
    }

    void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;

        SpeedBoost();
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float mouseXInput = Input.GetAxis("Mouse X");
        float mouseYInput = Input.GetAxis("Mouse Y");

        Vector3 direction = new Vector3(0, 0, verticalInput);
        Vector3 velocity = direction * _step;

        var rotationValue = mouseXInput * _step * 10;
        var rotationValue1 = -mouseYInput* _step * 10;
        transform.Rotate(rotationValue1, rotationValue, -horizontalInput);
        transform.Translate(velocity);
    }

    void SpeedBoost()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            _speedMultiplier = 3f;
        else
            _speedMultiplier = 1f;
    }
}
