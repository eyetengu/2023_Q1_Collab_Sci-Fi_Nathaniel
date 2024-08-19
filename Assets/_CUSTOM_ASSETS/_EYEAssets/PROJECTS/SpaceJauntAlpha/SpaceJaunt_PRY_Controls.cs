using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceJaunt_PRY_Controls : MonoBehaviour
{
    float _step;
    float _stepRotation;

    [SerializeField] float _speed = 3f;
    [SerializeField] float _rotationSpeed = 15.0f;
    [SerializeField] float _speedMultiplier = 1f;
    private float _maxSpeed = 5.0f;
    private float _minSpeed = -5.0f;
    [SerializeField] bool _goofyFoot;

    PRYCraftInputs _inputs;
    float _rollValue;
    float _pitchValue;
    float _yawValue;
    bool _isSpeeding;
    [SerializeField] SpaceJauntAlpha_UI_Manager _uiManager;


    void Start()
    {
        _inputs = new PRYCraftInputs();
        _inputs.PRYCraft.Enable();

        _inputs.PRYCraft.Acceleration.performed += Acceleration_performed;
        _inputs.PRYCraft.TurnToSide.performed += TurnToSide_performed;
        _inputs.PRYCraft.Pitch.performed += Pitch_performed;
        _inputs.PRYCraft.Roll.performed += Roll_performed;
        _inputs.PRYCraft.SpeedBoost.performed += SpeedBoost_performed;
        _inputs.PRYCraft.SpeedBoost.canceled += SpeedBoost_canceled;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void SpeedBoost_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _isSpeeding = false;
    }

    private void SpeedBoost_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _isSpeeding = true;
    }

    private void Roll_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _rollValue += _inputs.PRYCraft.Roll.ReadValue<float>();
    }

    private void Pitch_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _pitchValue += _inputs.PRYCraft.Pitch.ReadValue<float>();
    }

    private void TurnToSide_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _yawValue += _inputs.PRYCraft.TurnToSide.ReadValue<float>();
    }

    private void Acceleration_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _speed += _inputs.PRYCraft.Acceleration.ReadValue<float>();
    }


    void Update()
    {
        _speed += 3 * _inputs.PRYCraft.Acceleration.ReadValue<float>();

        _step = _speed * _speedMultiplier * Time.deltaTime;
        _stepRotation = _rotationSpeed * _speedMultiplier * Time.deltaTime;

        UserInput();
        Player_PRY_Move();
        DisplaySpeedOnUI();
    }

    void UserInput()
    {
        //ExitCursorLockState
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        //SpeedBoost

        if (Input.GetKey(KeyCode.LeftShift) || _isSpeeding)
            _speedMultiplier = 1.25f;
        else
            _speedMultiplier = 1.0f;

        //Accelerator & Brake
        if (Input.GetKey(KeyCode.W))
        {
            if (_speed < _maxSpeed)
                _speed += 0.2f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (_speed > _minSpeed)
                _speed -= 0.2f;
        }

    }

    void DisplaySpeedOnUI()
    {
        var velocity = _step;
        if (_uiManager != null)
            _uiManager.DisplaySpeed(velocity);
    }

    void Player_PRY_Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");

        float mouseX = Input.GetAxis("Horizontal1");
        float mouseY = Input.GetAxis("Vertical1");

        Vector3 direction = new Vector3(horizontalMove, 0, 1);
        Vector3 velocity = direction * _step;

        /*
        if(_goofyFoot)
            transform.Rotate(new Vector3(-mouseY, mouseX, -horizontalMove) * _stepRotation);        
        else
            transform.Rotate(new Vector3(mouseY, -mouseX, -horizontalMove) * _stepRotation);
        */


        if (_goofyFoot)
            transform.Rotate(new Vector3(_pitchValue, _yawValue, -_rollValue) * _stepRotation);
        else
            transform.Rotate(new Vector3(-_pitchValue, _yawValue, -_rollValue) * _stepRotation);


        transform.Translate(velocity);
    }


}
