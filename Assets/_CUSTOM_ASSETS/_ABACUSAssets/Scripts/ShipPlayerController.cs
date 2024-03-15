using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipPlayerController : MonoBehaviour
{
    public float verticalMoveSpeed;
    public float smoothingWeight;
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
        bool belowCamera = screenCoordinate.y < 0;
        bool aboveCamera = screenCoordinate.y > _camera.pixelHeight;
        if ((belowCamera && moveDirection.y < 0) ||
            (aboveCamera && moveDirection.y > 0))
        {
            moveDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
        }
        if (belowCamera)
        {
            Debug.Log(1 * verticalMoveSpeed * Time.deltaTime);
            moveDirection = new Vector3(moveDirection.x, 1 * verticalMoveSpeed *smoothingWeight * Time.deltaTime, moveDirection.z);
        };
        if (aboveCamera)
        {
            moveDirection = new Vector3(moveDirection.x, -1 * verticalMoveSpeed* smoothingWeight * Time.deltaTime, moveDirection.z);
        };
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection;
    }
}
