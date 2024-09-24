using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Rotate : MonoBehaviour
{
    Input_ConvoyDefender _defenderInputs;

    [Header("SPEED VALUES")]
    [SerializeField] private float _speed = 4f;
    private float _speedMultiplier = 1f;
    float _step;

    [Header("BOUNDING BOX")]
    [SerializeField] private float _maxXMovement;
    [SerializeField] private float _maxZMovement;
    bool _boosting;

    bool _gamePaused = true;


    //BUILT-IN FUNCTIONS
    private void OnEnable()
    {
        Event_Manager.gameReady += AllowGameControls;
        Event_Manager.gameOver += DisableGameControls;
        Event_Manager.lose += DisableGameControls;
    }

    private void OnDisable()
    {
        Event_Manager.gameReady -= AllowGameControls;
        Event_Manager.gameOver -= DisableGameControls;
        Event_Manager.lose -= DisableGameControls;
    }

    void AllowGameControls()
    {
        _gamePaused = false;
    }

    void DisableGameControls()
    {
        _gamePaused = true;
    }

    void Start()
    {
        _defenderInputs = new Input_ConvoyDefender();
        _defenderInputs.Defender.Enable();

        _defenderInputs.Defender.Boost.started += Boost_started;
        _defenderInputs.Defender.Boost.canceled += Boost_canceled;
    }

    private void Update()
    {
        if (_gamePaused == false)
        {
            if (_boosting)
                _speedMultiplier = 3.0f;
            else
                _speedMultiplier = 1.0f;

            PlayerBoundingBoxValues();
        }
    }

    private void Boost_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _speedMultiplier = 1.0f;
        _boosting = false;
    }

    private void Boost_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _speedMultiplier = 3.0f;
        _boosting = true;
    }

    void FixedUpdate()
    {
        if (_gamePaused == false)
        {
            _step = _speed * _speedMultiplier * Time.deltaTime;

            SpeedBoost();
            MovePlayer();
            //PlayerBoundingBoxValues();
        }
    }

    void MovePlayer()
    {
        if (_gamePaused == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            var horizSpeedRate = _defenderInputs.Defender.Turning.ReadValue<float>();
            var vertSpeedRate = _defenderInputs.Defender.Acceleration.ReadValue<float>();

            //Vector3 direction = new Vector3(0, 0, verticalInput);
            Vector3 direction = new Vector3(0, 0, -vertSpeedRate);

            Vector3 velocity = direction * _step;

            //var rotationValue = horizontalInput * _step * 10;
            var rotationValue = horizSpeedRate * _step * 10;

            transform.Rotate(0, rotationValue, 0);
            transform.Translate(velocity);
        }
    }

    void SpeedBoost()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            _speedMultiplier = 3f;
        else
            _speedMultiplier = 1f;
    }

    void PlayerBoundingBoxValues()
    {
        //X Values
        if (transform.position.x >= _maxXMovement)
            transform.position = new Vector3(_maxXMovement, transform.position.y, transform.position.z);
        if (transform.position.x <= -_maxXMovement)
            transform.position = new Vector3(-_maxXMovement, transform.position.y, transform.position.z);

        //Z Values
        if (transform.position.z >= _maxZMovement)
            transform.position = new Vector3(transform.position.x, transform.position.y, _maxZMovement);
        if (transform.position.z <= -_maxZMovement)
            transform.position = new Vector3(transform.position.x, transform.position.y, -_maxZMovement);
    }

}
