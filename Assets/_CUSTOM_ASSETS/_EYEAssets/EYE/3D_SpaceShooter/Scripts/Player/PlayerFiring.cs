using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiring : MonoBehaviour
{
    [SerializeField] private AudioManager_3DSpace _audioManager;

    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] Transform _firingPort;
    [SerializeField] Transform _ammoPouch;

    float _fireRate = 0.25f;
    float _canFire = -1f;

    private void Start()
    {
        _audioManager = GameObject.FindObjectOfType<AudioManager_3DSpace>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pew-Pew");
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        if (Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;

            var projectile = Instantiate(_projectilePrefab, _firingPort.position, _firingPort.rotation);
            projectile.transform.SetParent(_ammoPouch);

            _audioManager.ProjectileAudio();
        }
    }
}
