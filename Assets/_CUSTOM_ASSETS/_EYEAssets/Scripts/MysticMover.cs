using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MysticMover : MonoBehaviour
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

    private CharacterController _controller;

    bool _canJump;
    float _gravity = -1;
    float _yVelocity;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    void FixedUpdate()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;
        _rotationStep = _rotationSpeed * _rotationSpeedMultiplier * Time.deltaTime;

        float verticalInput = Input.GetAxis("Vertical");

        PlayerInputs(verticalInput);

        if(_controller.isGrounded)
        {
            _canJump = true;
            _yVelocity= 0;
        }
        else
        {
            _canJump= false;
            _yVelocity += _gravity;
        }    
        
        //float horizontalMovement = Input.GetAxis("Horizontal");
        //float horizontalCamera = Input.GetAxis("Mouse X");
        //float verticalCamera = Input.GetAxis("Mouse Y");
    }

    void PlayerInputs(float verticalInput)
    {
        if (Input.GetKeyDown(KeyCode.Space) && verticalInput > 0)
        {
            PlayerJump();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerCrouch();
        }
    }

    public void MovePlayer(Vector2 moveDir)
    {
        var direction = new Vector3(moveDir.x * _step, 0, moveDir.y * _step);
        
        _controller.Move(direction);

        //Animations
        if (moveDir.x != 0 || moveDir.y != 0)
        {
            _playerAnimator.WalkPlayer();
        }
        else
            _playerAnimator.PlayerIdle();
    }

    public void RotatePlayer(float rotateValue)
    {
        _controller.transform.Rotate(0, rotateValue * _rotationStep, 0);

        //_playerAnimator.RotatePlayer(_rotationStep);
    }

    void PlayerJump()
    {
        _playerAnimator.JumpPlayer();
    }

    void PlayerCrouch()
    {
        _playerAnimator.CrouchPlayer();
    }

    void RotateCamera(float mouseY)
    {
        _cameraPlatform.transform.Rotate(-mouseY, 0, 0);
    }
}
