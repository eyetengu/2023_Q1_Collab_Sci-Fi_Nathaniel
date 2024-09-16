using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeMount_Player : MonoBehaviour
{
    Animator _animator;
    CapsuleCollider _collider;
    Rigidbody _rb;

    [SerializeField] float _speed = 3.0f;
    float _speedMultiplier = 1.0f;
    float _step;
    
    bool _isDead;
    bool _inZone; 
    bool _canJump;
    bool _jumping;

    [SerializeField] float _jumpCooldown = 1.5f;
    [SerializeField] Vector3 _climbPosition;
    [SerializeField] Vector3 _finalPosition;


//BUILT-IN FUNCTIONS
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();    
        _collider = GetComponent<CapsuleCollider>();
        _rb = GetComponent<Rigidbody>();
        
        _canJump = true;
    }

    void Update()
    {
        if (_isDead == false)
        {
            _step = _speed * _speedMultiplier * Time.deltaTime;

            MovePlayerOnLevelField();
            UserInput();
        }
    }


//CORE FUNCTIONS
    void UserInput()
    {
        if (_inZone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerJumpRoutine();
            }
        }
    }

    void MovePlayerOnLevelField()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        transform.position += direction * _step;
    }

    void PlayerJumpRoutine()
    {
        if (_canJump)
        {
            _jumping = true;
            _canJump = false;

            transform.position += _climbPosition;

            _animator.SetTrigger("Jump");
            StartCoroutine(JumpTimer());
        }

        if (_jumping)
            MoveToFinalPosition();
    }

    void MoveToFinalPosition()
    {
        //_collider.enabled = false;
        transform.position = Vector3.MoveTowards(transform.position, _finalPosition, 0.01f);
    }


//TRIGGER FUNCTIONS
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        
        
        if(other.gameObject.name == "Ledge")
        {
            Debug.Log("Press E To Mount Ledge");
            _inZone = true;
        }
    }


//COROUTINES
    IEnumerator JumpTimer()
    {
        //MoveToFinalPosition();
        _rb.useGravity = false;
        yield return new WaitForSeconds(_jumpCooldown);
        _collider.enabled = true;
        _rb.useGravity = true;
        _canJump = true;
        _jumping = false;
    }

}
