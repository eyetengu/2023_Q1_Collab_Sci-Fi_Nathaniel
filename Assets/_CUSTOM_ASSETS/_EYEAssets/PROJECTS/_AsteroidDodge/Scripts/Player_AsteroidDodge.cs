using StandardAssets.Characters.ThirdPerson.AnimatorBehaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AsteroidDodge : MonoBehaviour
{
    Rigidbody _rigidbody;
    [SerializeField] float _speed = 3.0f;
    float _speedMultiplier = 1.0f;
    float _step;
    [SerializeField] GameObject _playerModelLeft;
    [SerializeField] GameObject _playerModelRight;

    [SerializeField] bool _basicPlayerMover;
    [SerializeField] bool _rbMover;

    [SerializeField] private float _maxVelocityLinear = 3.0f;
    [SerializeField] private float _jumpPower = 5;

//BUILT-IN FUNCTIONS
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxLinearVelocity = _maxVelocityLinear;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PlayerJump();
    }

    void FixedUpdate()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;

        PlayerInputs();
        
    }


//PLAYER MOVEMENT
    void PlayerInputs()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (_basicPlayerMover)
            BasicPlayerMover(horizontal, vertical);
        else if (_rbMover)
            RigidBodyMover(horizontal, vertical);
    }

    void RigidBodyMover(float horizontal, float vertical)
    {
        if (horizontal > 0)
            _rigidbody.AddForce(new Vector3(0, 0, 3));
        else if (horizontal < 0)
            _rigidbody.AddForce(new Vector3(0, 0, -3));

        if (vertical > 0)
        {
            _rigidbody.AddForce(new Vector3(-3, 0, 0));
            _rigidbody.maxLinearVelocity = _maxVelocityLinear;
        }
        else if (vertical < 0)
        {
            _rigidbody.AddForce(new Vector3(3, 0, 0));
            _rigidbody.maxLinearVelocity = _maxVelocityLinear;

        }


        var playerVelocity = _rigidbody.velocity;
        if (playerVelocity.z >= 2)
        {
            Debug.Log("Slow Down");
            //if(horizontal > 0)
                //_rigidbody.velocity = new Vector3(playerVelocity.x, playerVelocity.y, 2.0f);
            //if(horizontal < 0)
                //_rigidbody.velocity = new Vector3(playerVelocity.x, playerVelocity.y, 2.0f);

        }

        if(playerVelocity.x >= 2)
        {
            Debug.Log("Slow Down");
            //if (vertical > 0)
            //_rigidbody.velocity = new Vector3(2.0f, playerVelocity.y, playerVelocity.z);
            //if (vertical < 0)
            //_rigidbody.velocity = new Vector3(2.0f, playerVelocity.y, playerVelocity.z);
        }


    }

    void BasicPlayerMover(float horizontal, float vertical)
    {
        if (horizontal < 0)
        {
            _playerModelLeft.SetActive(true);
            _playerModelRight.SetActive(false);
        }
        else if (horizontal > 0)
        {
            _playerModelLeft.SetActive(false);
            _playerModelRight.SetActive(true);
        }

        if (Input.GetKey(KeyCode.LeftShift))
            _speedMultiplier = 2.0f;
        else
            _speedMultiplier = 1.0f;    


        Vector3 direction = new Vector3(-vertical, 0, horizontal) * _step;

        transform.position += direction;
    }

    void PlayerJump()
    {
        _rigidbody.AddForce(new Vector3(0, _jumpPower, 0), ForceMode.Impulse);
    }

}
