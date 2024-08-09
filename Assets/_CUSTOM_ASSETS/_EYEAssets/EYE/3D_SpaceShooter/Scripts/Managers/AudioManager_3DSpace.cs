using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_3DSpace : MonoBehaviour
{
    [Header("AMBIENCE MANAGER")]
    [SerializeField] AudioSource _ambient;
    [SerializeField] AudioClip _ambientClip;

    [Header("MUSIC MANAGER")]
    [SerializeField] AudioSource _music;
    [SerializeField] AudioClip _musicClip;

    [Header("GENERAL AUDIO MANAGER")]
    [SerializeField] AudioSource _general;
    [SerializeField] AudioClip _pickup_01;
    [SerializeField] AudioClip _explosionAudio;
    [SerializeField] AudioClip _projectileShoot;
    [SerializeField] AudioClip _bulletMetalRicochet;

    [Header("AUDIO CLIP LISTS")]
    [SerializeField] AudioClip[] _impacts;
    [SerializeField] AudioClip[] _fanfare;
    [SerializeField] AudioClip[] _tooBad;


    private void Start()
    {
        _ambient.PlayOneShot(_ambientClip);
    }

    public void PickupAudio()
    {
        _general.PlayOneShot(_pickup_01);
    }

    public void ExplosionAudio()
    {
        _general.PlayOneShot(_explosionAudio);
    }

    public void ProjectileAudio()
    {
        _general.PlayOneShot(_projectileShoot);
    }

    public void PlayFanfare()
    {
        var randomFanfare = _fanfare[Random.Range(0, _fanfare.Length-1)];        
        _general.PlayOneShot(randomFanfare);
    }

    public void PlayGameOver()
    {
        var randomGameOver = _tooBad[Random.Range(0, _tooBad.Length-1)];
        _music.PlayOneShot(_tooBad[0]);
    }

    public void PlayBulletMetalRicochet()
    {
        _general.PlayOneShot(_bulletMetalRicochet);
    }
}
