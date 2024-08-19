using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAnimation : MonoBehaviour
{
    public delegate void DeathAudio(AudioClip audio);
    public static event DeathAudio deathAudio;

    [SerializeField] GameObject _particleEffect;

    bool _trapSprung;
    Animator _animator;

    [SerializeField] AudioClip _deathAudioClip;


//BUILT-IN FUNCTIONS
    void Start()
    {
        _animator = GetComponent<Animator>();    
    }


//TRIGGER FUNCTIONS
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && _trapSprung == false)
        {
            //other.GetComponent<Rigidbody>().isKinematic = true;
            _trapSprung = true;
            _animator.SetBool("TrapActivated", true);
            if (deathAudio != null)
                deathAudio(_deathAudioClip);

            _particleEffect.transform.position = other.transform.position + new Vector3(0, 1.3f, 0);
            _particleEffect.SetActive(true);
            StartCoroutine(ResetTrapForNextVictim());
        }
    }


//COROUTINES
    IEnumerator ResetTrapForNextVictim()
    {        
        yield return new WaitForSeconds(2.0f);
        _animator.SetBool("TrapActivated", false);
        _trapSprung = false;
        _particleEffect.SetActive(false);
    }
}
