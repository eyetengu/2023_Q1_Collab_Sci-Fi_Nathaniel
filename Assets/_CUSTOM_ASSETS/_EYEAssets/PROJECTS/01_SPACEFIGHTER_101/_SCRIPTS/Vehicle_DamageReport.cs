using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle_DamageReport : MonoBehaviour, IDamageable
{
    bool _characterIsDead;

    AudioSource _audioSource;
    [SerializeField] AudioClip _explosionAudio;
    [SerializeField] GameObject _explosionObject;


    public int Health { get ; set; }

    public void Damage(int damageAmount)
    {
        if(Health > 0)
            Health -= damageAmount;
        if(Health < 0) Health = 0;

        if (Health == 0 && _characterIsDead == false)
        {
            Health = 0;
            _characterIsDead = true;
            _explosionObject.SetActive(true);
            Audio_Destroyed();
            
            //_audioSource.PlayOneShot(_explosionAudio);
            //audio explosion
            //vfx explosion
        }
    }


    void Start()
    {
        Health = 5;
        _characterIsDead = false;
        _audioSource = GetComponent<AudioSource>();
        _explosionObject.SetActive(false);
    }

    void Audio_Destroyed()
    {
        _audioSource.PlayOneShot(_explosionAudio);
    }

    void Update()
    {
        
    }
}
