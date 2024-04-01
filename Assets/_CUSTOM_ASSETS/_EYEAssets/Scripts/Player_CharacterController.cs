using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CharacterController : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    [SerializeField] float _rotationSpeed = 3f;
    [SerializeField] float _speedMultiplier = 1f;
    [SerializeField] float _rotationSpeedMultiplier = 30f;
    float _step;
    float _rotationStep;
    float _rotateValue;
    float _rotateCamVal;
    [SerializeField] Transform _cameraPlatform;
    private PlayerAnimator _playerAnimator;
    CharacterController _controller;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        //_agent = GetComponent<NavMeshAgent>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    void FixedUpdate()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;
        _rotationStep = _rotationSpeed * _rotationSpeedMultiplier * Time.deltaTime;

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float horizontalCamera = Input.GetAxis("Mouse X");
        float verticalCamera = Input.GetAxis("Mouse Y");

        if (Input.GetKeyDown(KeyCode.Space) && verticalInput > 0)
        {
            PlayerJump();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerCrouch();
        }

        //Movement
        Vector2 moveDir = new Vector2(horizontalMovement, verticalInput);
        Vector3 newMoveDir = new Vector3(-moveDir.x, 0, -moveDir.y);
        MovePlayer(moveDir * _step);

        //Rotations
        _rotateValue = horizontalCamera;
        RotatePlayer(_rotateValue * _rotationStep);
        _rotateCamVal = verticalCamera;
        RotateCamera(_rotateCamVal * _rotationStep);
    }

    public void MovePlayer(Vector2 moveDir)
    {
        var direction = new Vector3(moveDir.x, 0, moveDir.y);
        //transform.Translate(direction);

        _controller.Move(direction * _step);

        _playerAnimator.MovePlayer(moveDir);
    }

    public void RotatePlayer(float rotateValue)
    {
        //transform.Rotate(0, rotateValue * _rotationStep, 0);
        var newDirection = new Vector3(0, rotateValue, 0);
        _controller.transform.TransformDirection(newDirection * _step);
        _playerAnimator.RotatePlayer(_rotationStep);
    }

    void PlayerJump()
    {
        _playerAnimator.JumpPlayer();
    }

    void PlayerCrouch()
    {
        _playerAnimator.CrouchPlayer();
    }

    public void RotateCamera(float mouseY)
    {
        Debug.Log("Rotating Camera");
        _cameraPlatform.transform.Rotate(-mouseY, 0, 0);
    }
}
