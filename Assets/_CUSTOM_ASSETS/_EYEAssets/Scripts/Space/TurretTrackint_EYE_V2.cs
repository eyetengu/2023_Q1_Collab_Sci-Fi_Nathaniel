using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTrackint_EYE_V2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float xPos = Mathf.Clamp(horizontalInput, -10, 10);
        transform.Rotate(0, Mathf.Clamp(horizontalInput, -180, 180), 0) ;
    }
}
