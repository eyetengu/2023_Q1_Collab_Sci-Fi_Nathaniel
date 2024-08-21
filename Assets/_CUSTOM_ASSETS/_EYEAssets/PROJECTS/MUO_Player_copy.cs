using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class MUO_Player_copy : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public float speed;
    public float torque;
    private bool _isJumping = false;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        //MOVEMENT FORCES
        if (vInput > .25f)
            _rigidbody.AddForce(transform.forward * speed);
        if (vInput < -.25f)
            _rigidbody.AddForce(transform.forward * -1 * speed);

        //ROTATION
        _rigidbody.AddTorque(transform.up * torque * hInput);

        //MOVEMENT
        if (Input.GetKeyDown(KeyCode.W) && _isJumping == false)
        {
            _rigidbody.AddForce(transform.forward * speed);
        }

        //JUMPING
        if (!_isJumping)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isJumping = true;
                _rigidbody.AddForce(transform.up * speed * 120);
                _rigidbody.angularVelocity = Vector3.zero;
                Invoke("Move_Setter", 1f);
            }
        }
    }

    void Move_Setter()
    {
        _isJumping = false;
    }
}
