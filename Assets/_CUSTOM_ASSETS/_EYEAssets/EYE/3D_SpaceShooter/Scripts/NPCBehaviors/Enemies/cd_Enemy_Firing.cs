using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cd_Enemy_Firing : MonoBehaviour
{
    [Header("FIRING POINTS")]
    [SerializeField] private Transform _gunBarrel;

    [Header("PROJECTILE")]
    [SerializeField] private GameObject _laserPrefab;

    [Header("AMMO POUCH")]
    [SerializeField] private Transform _ammoPouch;
    
    [Header("AUDIO")]
    [SerializeField] AudioClip _gunShotAudio;
    AudioSource _audioSource;

    bool _firing;
    float _fireRate = 0.5f;
    float _canFire = 1.0f;


    public bool Firing { get; set; }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    void FireAtWill()
    {
        if (Firing)
        {
            if (Time.time > _canFire)
            {
                _canFire = Time.time + _fireRate;
                var laserShot = Instantiate(_laserPrefab, _gunBarrel.position, _gunBarrel.rotation);
                laserShot.transform.SetParent(_ammoPouch);
                _audioSource.PlayOneShot(_gunShotAudio);
            }
        }
    }
}
