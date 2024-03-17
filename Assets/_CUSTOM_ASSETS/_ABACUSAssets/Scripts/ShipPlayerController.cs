using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipPlayerController : MonoBehaviour
{
    public float verticalMoveSpeed;
    public float smoothingWeight;
    Vector3 moveDirection = Vector3.zero;
    Vector2 inputDirection = Vector2.zero;
    Rigidbody rb;
    private Camera _camera;
    public float forwardForce;
    
    [SerializeField]
    private GameObject _lazerGameObj;
    
    private ShipPlayerAction _playerAction;
    private InputAction _moveAction;

    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = -1;


    public void Awake()
    {
        _playerAction = new ShipPlayerAction();
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
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        inputDirection = _moveAction.ReadValue<Vector2>();
        moveDirection = new Vector3(0, inputDirection.y * verticalMoveSpeed, forwardForce);
        CheckCameraViewPortBeforeMovement();
    }

    private void CheckCameraViewPortBeforeMovement()
    {
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
            moveDirection = new Vector3(moveDirection.x, 1 * verticalMoveSpeed * smoothingWeight * Time.deltaTime, moveDirection.z);
        };
        if (aboveCamera)
        {
            moveDirection = new Vector3(moveDirection.x, -1 * verticalMoveSpeed * smoothingWeight * Time.deltaTime, moveDirection.z);
        };
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection;
    }
    private void Fire_performed(InputAction.CallbackContext context)
    {
        if(Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_lazerGameObj, transform.position, Quaternion.identity, transform.parent);
        }
    }
    private void OnEnable()
    {
        _moveAction = _playerAction.Player.Move;
        _moveAction.Enable();
        _playerAction.Player.Fire.performed += Fire_performed;
        _playerAction.Player.Fire.Enable();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _playerAction.Player.Fire.performed -= Fire_performed;
        _playerAction.Player.Fire.Disable();
    }

}
