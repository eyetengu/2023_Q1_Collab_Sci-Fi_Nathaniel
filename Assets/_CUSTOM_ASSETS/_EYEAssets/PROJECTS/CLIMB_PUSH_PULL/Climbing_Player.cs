using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing_Player : MonoBehaviour
{
    Animator _animator;
    [SerializeField] float _speed = 0.5f;
    [SerializeField] float _lateralSpeed = 0.4f;

    float _speedMultiplier = 1.0f;
    float _step;
    float _lateralStep;

    bool _isMounting, _jumping;


    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;
        _lateralStep = _lateralSpeed * Time.deltaTime;

        UserInput();
        MovePlayerOnXAndY();
    }

    void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.M))        
            PlayerIsMountingLedge();        

        if (Input.GetKeyDown(KeyCode.J))
            PlayerJump();
    }

    void MovePlayerOnXAndY()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(vertical == 0 && horizontal == 0)
        {
            _animator.SetBool("Right", false);
            _animator.SetBool("Left",  false);
            _animator.SetBool("Up",    false);
            _animator.SetBool("Down",  false);
        }

        if (vertical > 0)
        {   _animator.SetBool("Up",   true);
            _animator.SetBool("Down", false);
        }
        else if(vertical < 0)
        {
            _animator.SetBool("Down", true);
            _animator.SetBool("Up",   false);
        }

        if (horizontal > 0)
        {
            _animator.SetBool("Right", true);
            _animator.SetBool("Left",  false);
        }
        else if (horizontal < 0)
        {
            _animator.SetBool("Right", false);
            _animator.SetBool("Left",  true);
        }

        Vector3 direction = new Vector3(horizontal * _lateralStep, vertical * _step, 0);
        transform.position += direction;
    }

    void PlayerJump()
    {
        if (_jumping == false)
        {
            _jumping = true;
            _animator.SetTrigger("Jump");
            //_audioManager.PlayOneShot("MaleJump");
            StartCoroutine(JumpTimer());
        }
    }

    public void PlayerIsMountingLedge()
    {
        if (_isMounting == false)
        {            
            _isMounting = true;
            _animator.SetTrigger("Mount");
            StartCoroutine(MountTimer());
            //_audioManager.PlayOneShot("MaleExert");
        }
    }
    
    IEnumerator MountTimer()
    {
        transform.position += new Vector3(0, 0.5f, 0);
        yield return new WaitForSeconds(2.0f);
        _isMounting = false;
        transform.position += new Vector3(0, 1.0f, 0);
    }

    IEnumerator JumpTimer()
    {
        yield return new WaitForSeconds(1.5f);
        _jumping = false;
    }
}
