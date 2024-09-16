using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate_pusher_Player : MonoBehaviour
{
    RaycastHit hitInfo;
    Animator _animator;
    [SerializeField] float _speed = 3.0f;
    [SerializeField] float _rotationSpeed = 10.0f;

    float _speedMultiplier = 1.0f;
    float _step;
    float _rotationStep;

    bool _movingCrate;


    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;
        _rotationStep = _rotationSpeed * Time.deltaTime;

        MovePlayer();
        CheckRaycastHit();
    }

    private void FixedUpdate()
    {
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(0, 0, vertical);
        
        if(_movingCrate == false)
            transform.Rotate(0, horizontal * _rotationStep, 0);
    
        transform.position += transform.forward * vertical * _step;
    }

    void CheckRaycastHit()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(transform.forward), out hitInfo))
        {
            Debug.Log("Crate Push Enabled " + hitInfo.collider.name);
            if (hitInfo.collider.name == "Crate" && Input.GetKeyDown(KeyCode.E))
            {
                _movingCrate = !_movingCrate;
                if (_movingCrate)
                {
                    _animator.SetBool("Walking", true);
                    _animator.SetBool("Forward", true);
                }
            }

        }
        Debug.Log("Moving Crate: " + _movingCrate);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Crate")
        {

        }
    }

}
