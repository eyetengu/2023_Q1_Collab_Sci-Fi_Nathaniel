using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover_Interface : MonoBehaviour
{
    [SerializeField] float _speed = 2.0f;
    float _step;

    [SerializeField] float _rotationSpeed = 5.0f;
    float _rotationStep;
    bool _playerIsDead;


//BUILT-IN FUNCTIONS
    private void OnEnable()
    {
        Player_Health.playerHasDied += KillPlayer;
    }

    private void OnDisable()
    {
        Player_Health.playerHasDied -= KillPlayer;
    }

    void Update()
    {
        if (_playerIsDead == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            _step = vertical * _speed * Time.deltaTime;
            _rotationStep = horizontal * _rotationSpeed * Time.deltaTime;

            //Vector3 direction = new Vector3(0, 0, vertical);
            transform.Rotate(0, 15 * _rotationStep, 0);

            transform.position += transform.forward * _step;
        }
    }


//CORE FUNCTIONS
    void KillPlayer()
    {
        _playerIsDead = true;
    }
}
