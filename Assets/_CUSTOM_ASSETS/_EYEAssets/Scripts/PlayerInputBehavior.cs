using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputBehavior : MonoBehaviour
{
    EYEInputControls _inputs;
    FlyingVehicleBehavior _flyingMovement;
    bool _boolcondition;
    
    void Start()
    {
        _inputs = new EYEInputControls();
        _inputs.FlyingCar.Enable();

        _flyingMovement = GetComponent<FlyingVehicleBehavior>();        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _boolcondition = !_boolcondition;

            if(_boolcondition)
                SwitchTo_CharacterControl();
            else
                SwitchTo_SkyCarControl();
        }

        var vehicleMovement = _inputs.FlyingCar.Movement.ReadValue<Vector2>();
        var vehicleRotation = _inputs.FlyingCar.Rotation.ReadValue<Vector2>();

        //left stick action
        var rotate_Yaw = vehicleMovement.x;
        var forwardMovement = vehicleMovement.y;
        
        //right stick action
        var rotate_roll = vehicleRotation.x;
        var rotate_Pitch = vehicleRotation.y;

        _flyingMovement.MoveFlyingVehicle(forwardMovement);

        _flyingMovement.RotateFlyingVehicle(rotate_Pitch, rotate_roll, -rotate_Yaw);        
    }

    void SwitchTo_CharacterControl()
    {
        _inputs.FlyingCar.Disable();
        _inputs.Player.Enable();
    }

    void SwitchTo_SkyCarControl()
    {
        _inputs.FlyingCar.Enable(); 
        _inputs.Player.Disable();
    }
}
