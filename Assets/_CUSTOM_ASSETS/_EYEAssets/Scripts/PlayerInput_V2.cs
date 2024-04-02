using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput_V2 : MonoBehaviour
{
    PlayerInside_Controller _playerController;
    //MysticMover _playerMover;
    //Player_CharacterController _playerMover;
    PlayerMover _playerMover;


    void Start()
    {
        //_playerMover = GetComponent<MysticMover>();
        //_playerMover = GetComponent<Player_CharacterController>();
        _playerMover = GetComponent<PlayerMover>();
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
