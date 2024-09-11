using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSEnemyMovementDown : MonoBehaviour
{
    public float speed = 5f; // Speed of the enemy
    public float frequency = 1f; // Frequency of the sine wave
    public float amplitude = 1f; // Amplitude of the sine wave

    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;
        float x = Mathf.Sin(elapsedTime * frequency) * amplitude;
        float y = -elapsedTime * speed; // Change the direction to move downwards

        transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
        if (transform.position.y < -300f) // Adjust the condition to check if the object is below a certain point
        {
            Destroy(gameObject);
        }
    }
}
