using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceVehicle : MonoBehaviour
{
    EYEInputControls _inputs;

    public float speed = 10f;

    float roll;
    float pitch;
    float yaw;

    private bool _applyThrusters;


    private void Start()
    {
        _inputs = new EYEInputControls();
        _inputs.SpaceFlight.Enable();

        _inputs.SpaceFlight.Thrusters.started += Thrusters_performed;
        _inputs.SpaceFlight.Thrusters.canceled += Thrusters_canceled;

    }

    private void Thrusters_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _applyThrusters = true;        
    }

    private void Thrusters_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _applyThrusters = false;
    }

    private void Update()
    {
        var rollXbox = _inputs.SpaceFlight.Roll.ReadValue<float>();
        var pitchXbox = _inputs.SpaceFlight.Pitch.ReadValue<float>();
        roll = Input.GetAxisRaw("Horizontal");
        pitch = Input.GetAxisRaw("Vertical");

        transform.Rotate(Vector3.back * rollXbox * 100f * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.right * pitchXbox * 100f * Time.deltaTime, Space.Self);

        if (_applyThrusters)
            ApplyForwardThrust();
    }

    void ApplyForwardThrust()
    {
        //if (Input.GetKey(KeyCode.Space)) 
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
