using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_VFX_LocalAudio : MonoBehaviour
{
    [SerializeField] GameObject _visualEffectObject;
    [SerializeField] AudioClip _audioClip;
    AudioSource _audioSource;


    void Start()
    {
        _audioSource = GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        _audioSource.PlayOneShot(_audioClip);
        _visualEffectObject.SetActive(true);
        StartCoroutine(ResetVFXTimer());
    }

    IEnumerator ResetVFXTimer()
    {
        yield return new WaitForSeconds(1.0f);
        _visualEffectObject.SetActive(false);
    }
}
