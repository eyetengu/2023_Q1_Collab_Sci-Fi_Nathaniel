using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController3D : MonoBehaviour
{
    // Public variables
    public float maxSpeed = 100f;
    public float acceleration = 30f;
    public float steering = 2f;
    public float driftFactor = 0.95f;
    public float normalFactor = 0.9f;
    public float boostMultiplier = 2f;
    public float boostDuration = 2f;
    public bool isDrifting { get { return _isDrifting; } }
    public bool isBoosting {  get { return _isBoosting; } }
    public float CurrentSpeed { get { return _currentSpeed; } }
    // Private variables
    private Rigidbody rb;
    private float speedInput;
    private float turnInput;
    private bool _isDrifting;
    private bool _isBoosting;
    private float boostEndTime;
    private float _currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        // Get input for acceleration and steering
        speedInput = Input.GetAxis("Vertical") * acceleration;
        turnInput = Input.GetAxis("Horizontal");

        _currentSpeed = rb.velocity.magnitude;
        // Check if the car is drifting
        _isDrifting = Mathf.Abs(turnInput) > 0.5f && _currentSpeed > 5f;

        // Check for boost input
        if (Input.GetKeyDown(KeyCode.Space) && !isBoosting)
        {
            _isBoosting = true;
            boostEndTime = Time.time + boostDuration;
        }

        // Disable boost when duration ends
        if (isBoosting && Time.time > boostEndTime)
        {
            _isBoosting = false;
        }
    }

    void FixedUpdate()
    {
        // Apply forward force
        float currentMaxSpeed = isBoosting ? maxSpeed * boostMultiplier : maxSpeed;

        if (speedInput != 0)
        {
            rb.AddForce(transform.forward * speedInput * (isBoosting ? boostMultiplier : 1f));
        }

        // Limit the speed
        if (rb.velocity.magnitude > currentMaxSpeed)
        {
            rb.velocity = rb.velocity.normalized * currentMaxSpeed;
        }

        // Calculate drift and normal factors
        float driftFactorToUse = isDrifting ? driftFactor : normalFactor;

        // Apply the drift factor
        Vector3 forwardVelocity = transform.forward * Vector3.Dot(rb.velocity, transform.forward);
        Vector3 rightVelocity = transform.right * Vector3.Dot(rb.velocity, transform.right);

        rb.velocity = forwardVelocity + rightVelocity * driftFactorToUse;

        // Apply steering
        float turn = turnInput * steering * rb.velocity.magnitude / currentMaxSpeed;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, turn, 0));
    }
}
