using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRotatorX : MonoBehaviour
{
    private const int NEGATIVE_VALUE = -1;

    // Variable to control the rotation speed
    [SerializeField] private float rotationSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        var player = RSPlayer.Instance;
        if (player != null)
        {
            var isRightFacing = player.isRightFacing;
            if (isRightFacing)
            {
                // Rotate the object around its Y-axis at the specified speed
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.up * NEGATIVE_VALUE * rotationSpeed * Time.deltaTime);

            }
        }
    }
}
