using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiring : MonoBehaviour
{
    [SerializeField] private AudioManager_3DSpace _audioManager;

    Input_ConvoyDefender _defenderInputs;

    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] Transform _firingPort;
    [SerializeField] Transform _ammoPouch;

    float _fireRate = 0.25f;
    float _canFire = -1f;
    bool _gameOver;


    //BUILT-IN FUNCTIONS
    private void OnEnable()
    {
        Event_Manager.gameReady += Event_Manager_gameReady;
        Event_Manager.gameOver += Event_Manager_gameOver;
        Event_Manager.lose += Event_Manager_gameOver;
        Event_Manager.win += Event_Manager_gameOver;
    }

    private void OnDisable()
    {
        Event_Manager.gameReady -= Event_Manager_gameReady;
        Event_Manager.gameOver -= Event_Manager_gameOver;
        Event_Manager.lose -= Event_Manager_gameOver;
        Event_Manager.win -= Event_Manager_gameOver;
    }

    private void Event_Manager_gameReady()
    {
        _gameOver = false;
    }

    private void Event_Manager_gameOver()
    {
        _gameOver = true;
    }

    private void Start()
    {
        _audioManager = GameObject.FindObjectOfType<AudioManager_3DSpace>();

        _defenderInputs = new Input_ConvoyDefender();
        _defenderInputs.Defender.Enable();

        _defenderInputs.Defender.Firing.performed += FireProjectile ;
    }


    //CORE FUNCTIONS
    void FireProjectile(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_gameOver == false)
        {
            if (Time.time > _canFire)
            {
                _canFire = Time.time + _fireRate;

                var projectile = Instantiate(_projectilePrefab, _firingPort.position, _firingPort.rotation);
                if (projectile != null)
                    projectile.transform.SetParent(_ammoPouch);
                if (_audioManager != null)
                {
                    _audioManager.ProjectileAudio();
                }
            }
        }
    }
}
