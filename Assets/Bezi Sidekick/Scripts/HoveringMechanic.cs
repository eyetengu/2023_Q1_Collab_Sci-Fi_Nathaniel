using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveringMechanic : MonoBehaviour
{
    public Transform target; // The object this one will orbit around
    public float hoverHeight = 2.0f; // Height above the target
    public float hoverSpeed = 2.0f; // Speed of the hover movement
    private float currentHoverTime = 0.0f; // Internal timer to track hover progress

    void Update()
    {
        Hovering();
    }

    void Hovering()
    {
        if (target == null)
            return;

        currentHoverTime += Time.deltaTime * hoverSpeed;
        float newY = Mathf.Sin(currentHoverTime) * hoverHeight;
        transform.position = new Vector3(target.position.x, target.position.y + newY, target.position.z);
    }
}
