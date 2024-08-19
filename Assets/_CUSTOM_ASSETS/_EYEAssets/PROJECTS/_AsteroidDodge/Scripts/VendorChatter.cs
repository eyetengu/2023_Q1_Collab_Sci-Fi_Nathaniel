using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorChatter : MonoBehaviour
{
    AudioSource _audioSource;

    [SerializeField] private AudioClip[] _vendorAudio;
    int _clipID;
    [SerializeField] bool _playRandomClips;


    void Start()
    {
        _audioSource = GetComponent<AudioSource>();   
    }

    void Update()
    {
        if (!_audioSource.isPlaying)
            ChooseNextAudioClip();
    }

    void ChooseNextAudioClip()
    {
        if (_playRandomClips)
        {
            _clipID = Random.Range(0, _vendorAudio.Length - 1);
            PlayCurrentAudioClip();
        }
        else
        {
            _clipID++;
            if (_clipID > _vendorAudio.Length - 1)
                _clipID = 0;
            PlayCurrentAudioClip();
        }
    }

    void PlayCurrentAudioClip()
    {
        _audioSource.PlayOneShot(_vendorAudio[_clipID]);
    }
}
