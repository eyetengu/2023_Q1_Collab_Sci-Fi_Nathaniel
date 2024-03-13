using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipPlayerController : MonoBehaviour
{
    public float verticalMoveSpeed;
    public InputAction inputAction;
    Vector3 moveDirection = Vector3.zero;
    Rigidbody rb;
    private Camera _camera;
    public float forwardForce;
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
        moveDirection = new Vector3(0, inputDirection.y * verticalMoveSpeed, forwardForce);
        Vector3 screenCoordinate = _camera.WorldToScreenPoint(transform.position);
        if ((screenCoordinate.y < 0 && moveDirection.y < 0) ||
            (screenCoordinate.y > _camera.pixelHeight && moveDirection.y > 0))
        {
            moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
        }
    }

    private void FixedUpdate()
    {  
        rb.velocity = moveDirection;
    }
}
