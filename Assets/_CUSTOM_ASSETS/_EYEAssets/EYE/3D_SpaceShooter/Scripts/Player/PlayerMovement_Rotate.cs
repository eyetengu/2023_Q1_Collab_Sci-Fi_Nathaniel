using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Rotate : MonoBehaviour
{
    float _step;
    [SerializeField] private float _speed = 4f;
    private float _speedMultiplier = 1f;
    [SerializeField] private float _maxXMovement;
    [SerializeField] private float _maxZMovement;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;

        SpeedBoost();
        MovePlayer();
        //PlayerBoundingBoxValues();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(0, 0, verticalInput);
        Vector3 velocity = direction * _step;

        var rotationValue = horizontalInput * _step * 10;
        transform.Rotate(0, rotationValue, 0);
        transform.Translate(velocity);
    }

    void SpeedBoost()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            _speedMultiplier = 3f;
        else
            _speedMultiplier = 1f;
    }

    void PlayerBoundingBoxValues()
    {
        //X Values
        if (transform.position.x >= _maxXMovement)
            transform.position = new Vector3(_maxXMovement, transform.position.y, transform.position.z);
        if (transform.position.x <= -_maxXMovement)
            transform.position = new Vector3(-_maxXMovement, transform.position.y, transform.position.z);

        //Z Values
        if (transform.position.z >= _maxZMovement)
            transform.position = new Vector3(transform.position.x, transform.position.y, _maxZMovement);
        if (transform.position.z <= -_maxZMovement)
            transform.position = new Vector3(transform.position.x, transform.position.y, -_maxZMovement);
    }

}
