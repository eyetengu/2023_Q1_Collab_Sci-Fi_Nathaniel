using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour
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
    CapsuleCollider _collider;
    [SerializeField] float _jumpDelay = 0.5f;
    bool _canJump;



    void Start()
    {
        //_agent = GetComponent<NavMeshAgent>();
        _playerAnimator= GetComponent<PlayerAnimator>();
        _collider = GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;
        _rotationStep = _rotationSpeed * _rotationSpeedMultiplier * Time.deltaTime;

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float horizontalCamera = Input.GetAxis("Mouse X");
        float verticalCamera = Input.GetAxis("Mouse Y");

        if (Input.GetKey(KeyCode.LeftShift))
            _speedMultiplier = 2.0f;
        else
            _speedMultiplier = 1.0f;

        if(Input.GetKeyDown(KeyCode.Space) && verticalInput > 0 && _canJump)        
            PlayerJump();

        if (Input.GetKey(KeyCode.C))
            PlayerCrouch();
        else
            PlayerStandUp();

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
        transform.Translate (direction * _step);

        _playerAnimator.MovePlayer(moveDir);
    }

    public void RotatePlayer(float rotateValue)
    {
        transform.Rotate(0, rotateValue * _rotationStep, 0);

        _playerAnimator.RotatePlayer(_rotationStep);
    }

    void PlayerJump()
    {
        _playerAnimator.JumpPlayer();
    }

    void PlayerCrouch()
    {
        _playerAnimator.CrouchPlayer();
        _collider.radius = 0.5f;
    }

    void PlayerStandUp()
    {_playerAnimator.PlayerIdle();
        _collider.radius = 1.0f;
    }

    public void RotateCamera(float mouseY)
    {
        Debug.Log("Rotating Camera");
        _cameraPlatform.transform.Rotate(-mouseY, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    IEnumerator JumpTimer()
    {
        yield return new WaitForSeconds(_jumpDelay);
        _collider.radius = 1.0f;
        _canJump = true;
    }
}
