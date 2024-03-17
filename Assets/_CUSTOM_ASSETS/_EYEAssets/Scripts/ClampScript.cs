using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float xRotation = Input.GetAxis("Mouse X");
        float yRotation = Input.GetAxis("Mouse Y");      

        var direction = new Vector3(horizontalInput, 0, verticalInput);
        horizontalInput = Mathf.Clamp(horizontalInput, -5, 5);
        verticalInput = Mathf.Clamp(verticalInput, -5, 5);

        transform.Translate(direction);
    }
}
