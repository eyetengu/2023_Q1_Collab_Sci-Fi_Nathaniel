using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput_V2 : MonoBehaviour
{
    PlayerInside_Controller _playerController;
    MysticMover _playerMover;

    
    void Start()
    {
        _playerMover = GetComponent<MysticMover>();

        _playerController= new PlayerInside_Controller();
        _playerController.Player.Enable();
    }

    
    void Update()
    {
        var movement = _playerController.Player.Move.ReadValue<Vector2>();
        var turnRate = _playerController.Player.TurnPlayer.ReadValue<float>();
        var turnValue = _playerController.Player.TurnPlayer.ReadValue<float>();
        var cameraRotValue = _playerController.Player.TurnPlayer.ReadValue<float>();

        _playerMover.MovePlayer(movement);
        _playerMover.RotatePlayer(turnRate);
    }
}
