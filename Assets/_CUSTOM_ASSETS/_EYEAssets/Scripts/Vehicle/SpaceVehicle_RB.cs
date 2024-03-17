using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceVehicle_RB : MonoBehaviour
{
    float verticalMove;
    float horizontalMove;
    float rollInput;
    float mouseInputX;
    float mouseInputY;


    [SerializeField] float speedMult = 1.0f;
    [SerializeField] float speedMultAngle = 0.5f;
    [SerializeField] float speedRollMultAngle = 0.05f;

    Rigidbody spaceshipRB;




    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        spaceshipRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        verticalMove = Input.GetAxis("Vertical");
        horizontalMove = Input.GetAxis("Horizontal");
        rollInput = Input.GetAxis("Roll");

        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = Input.GetAxis("Mouse Y"); 
    }
    void FixedUpdate()
    {
        spaceshipRB.AddForce(spaceshipRB.transform.TransformDirection(Vector3.forward) * verticalMove * speedMult, ForceMode.VelocityChange);
    }
}
