using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hover_Behavior : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float length;
    [SerializeField] float strength;
    [SerializeField] float dampening;
    [SerializeField] float lastHitDist;
    [SerializeField] float antiGravityForce = 9.81f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CounterGravity();
    }
    
    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, length))
        {
            float forceAmount = HooksLawDampen(hit.distance);

            rb.AddForceAtPosition(transform.up * forceAmount, transform.position);
        }
        else
        {
            lastHitDist = length * 1.1f;
        }
    }

    private float HooksLawDampen(float hitDistance)
    {
        float forceAmount = strength * (length - hitDistance) + (dampening * (lastHitDist - hitDistance));
        forceAmount = Mathf.Max(0f, forceAmount);
        lastHitDist = hitDistance;

        return forceAmount;
    }

    void CounterGravity()
    {
        rb.AddForceAtPosition(antiGravityForce * rb.mass * Vector3.up, rb.centerOfMass);
    }
}
