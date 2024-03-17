using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour
{
    public float speed = 3f; // Speed of movement
    public float amplitude = 1f; // Amplitude of the sine wave
    public float frequency = 2f; // Frequency of the sine wave

    private float startTime;
    private float initialY;

    private void Start()
    {
        startTime = Time.time; // Record the start time
        initialY = transform.position.y;
    }

    private void Update()
    {
        // Calculate the vertical offset based on sine wave
        float yOffset = Mathf.Sin((Time.time - startTime) * frequency) * amplitude;

        // Move the enemy horizontally
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Update the position with the vertical offset
        transform.position = new Vector3(transform.position.x, yOffset + initialY, transform.position.z);
    }
}
