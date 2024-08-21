using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FlyingVehicleBehavior : MonoBehaviour
{
    float _driveStep;
    float _hoverStep;
    [SerializeField]
    float _speed = .5f;
    float _turnSpeed = 20f;
    float _speedMultiplier = 1f;
    [SerializeField]
    float _hoverMultiplier = 1f;
    bool _isHoverUp;
    bool _switchHover;
    private Animator _animator;
    bool _canMoveDown;
    bool _canRotate;

    void Start()
    {
        _animator = GetComponent<Animator>();

        StartCoroutine(HoverChangeTimer());
    }

    void Update()
    {
        _driveStep = _speed * _speedMultiplier * Time.deltaTime;
        _hoverStep = .05f * _hoverMultiplier * Time.deltaTime;
        
        VehicleHover();

    }

    void CheckUserInput()
    {
        //SpeedBoost
        if (Input.GetKey(KeyCode.LeftShift))
            _speedMultiplier = 2f;
        else
            _speedMultiplier = 1f;

    }

    public void MoveFlyingVehicle(float moveDirection)
    {
        if(moveDirection > 0)
        {
            _canRotate= true;
            transform.Translate(new Vector3(0, 0, moveDirection * _driveStep));
        }
    }

    public void RotateFlyingVehicle(float pitch, float roll, float yaw)
    {
        if (_canRotate)
        {
            if (pitch == 0 && roll == 0 && yaw == 0)
            {
                transform.Rotate(0, 0, 0);
            }
            else
                transform.Rotate(pitch, -yaw, -roll);
        }
    }


    




    //-----------------------------


    void VehicleHover()
    {
        if(_switchHover)
        {
            _switchHover = false;
            
            _isHoverUp = !_isHoverUp;

            if (_isHoverUp)
                _hoverMultiplier = 1f;
            else
                _hoverMultiplier = -1f;

            StartCoroutine(HoverChangeTimer());
        }
            
        transform.Translate(new Vector3(0, _hoverStep, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        { 
            _canMoveDown = false;
        }
    }

    IEnumerator HoverChangeTimer()
    {
        yield return new WaitForSeconds(.3f);
        _switchHover = !_switchHover;
    }
    void AnimateVehicle(float hIn, float vIn, float mX, float mY)
    {        
        if (hIn < 0)
            _animator.SetTrigger("BankLeft");
        if (hIn > 0)
            _animator.SetTrigger("BankRight");
    }
}
