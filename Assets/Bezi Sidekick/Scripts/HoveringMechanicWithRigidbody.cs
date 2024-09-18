using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HoveringMechanicWithRigidbody : MonoBehaviour
{
    public Transform target; // The object this one will hover around
    public float hoverHeight = 2.0f; // Height above the target
    public float hoverForce = 5.0f; // Force applied to create the hover effect
    public float damping = 0.5f; // Damping effect to stabilize the hover
    private Rigidbody rb;

    // PID Controller terms
    public float kP = 1.0f; // Proportional gain
    public float kI = 0.1f; // Integral gain
    public float kD = 0.01f; // Derivative gain

    private float integral = 0.0f;
    private float previousError = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable gravity for hovering
    }

    void FixedUpdate()
    {
        PIDHover();
    }

    void PIDHover()
    {
        if (target == null)
            return;
        
        // Calculate the error between desired height and current height
        float error = (target.position.y + hoverHeight) - transform.position.y;

        // Calculate integral and derivative components
        integral += error * Time.fixedDeltaTime;
        float derivative = (error - previousError) / Time.fixedDeltaTime;

        // Calculate PID output
        float output = (kP * error) + (kI * integral) + (kD * derivative);

        // Apply force to hovercraft using PID output
        rb.AddForce(Vector3.up * output, ForceMode.Acceleration);

        // Update previous error
        previousError = error;
    }
}
