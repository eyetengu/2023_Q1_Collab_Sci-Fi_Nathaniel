using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipPlayerController : MonoBehaviour
{
    public float moveSpeed;
    public InputAction inputAction;
    Vector3 moveDirection = Vector3.zero;
    Rigidbody rb;
    private Camera _camera;

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var inputDirection = inputAction.ReadValue<Vector2>();
        moveDirection = new Vector3(0, inputDirection.y * moveSpeed, 0);
    }

    private void FixedUpdate()
    {  
        rb.velocity = moveDirection;
        Vector3 screenCoordinate = _camera.WorldToScreenPoint(transform.position);
        if((screenCoordinate.y < 0 && rb.velocity.y < 0)|| 
            (screenCoordinate.y > _camera.pixelHeight && rb.velocity.y > 0))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0);
        }
    }
}
