using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Speed of camera movement
    public float heightOffset = 5f; // Adjustable height offset from the player

    private Vector3 offset; // Initial offset between camera and player

    void Start()
    {
        offset = transform.position - target.position; // Calculate initial offset
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }
        Vector3 desiredPosition = target.position + offset + Vector3.up * heightOffset; // Calculate desired camera position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Smoothly move the camera
        transform.position = smoothedPosition; // Update camera position to the smoothed position
        transform.LookAt(target.position); // Ensure the camera is always looking at the player
    }
}