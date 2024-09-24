using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    AudioSource _audioSource;
    [SerializeField] AudioClip[] _clips;


    private void OnEnable()
    {
        Player_Health.playerHasDied += PlayerDead;
    }

    void OnDisable()
    {
        Player_Health.playerHasDied -= PlayerDead;
    }

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayerDead()
    {
        _audioSource.PlayOneShot(_clips[0]);
    }
    
    public void PlayPickup()
    {
        _audioSource.PlayOneShot(_clips[1]);
    }

    public void PlayPoison()
    {
        _audioSource.PlayOneShot(_clips[2]);
    }

    public void PlayCure()
    {
        _audioSource.PlayOneShot(_clips[3]);
    }
}
