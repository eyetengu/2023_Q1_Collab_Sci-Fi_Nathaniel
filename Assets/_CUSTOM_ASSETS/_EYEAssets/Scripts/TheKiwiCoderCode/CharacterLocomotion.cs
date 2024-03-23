using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    Animator _animator;
    Vector2 _input;
    float _speed = 3f;
    float _speedMultiplier = 1f;
    float _step;


    void Start()
    {
        _animator= GetComponent<Animator>();
    }
    
    void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;

        _input.x = Input.GetAxis("Horizontal");
        _input.y = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(_input.x,0, _input.y) * _step); 

        _animator.SetFloat("InputX", _input.x);
        _animator.SetFloat("InputY", _input.y);
    }
}
