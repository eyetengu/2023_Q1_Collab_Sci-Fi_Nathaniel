using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Collectible_Manager : MonoBehaviour
{
    float _value;

    [SerializeField] private float _experience;
    [SerializeField] private float _gold;
    [SerializeField] private float _health;
    [SerializeField] private float _score;

    [SerializeField] string _audioClipName;
    AudioSource _audioSource;

    bool _hasClipPlayed;


    //BUILT-IN FUNCTIONS
    private void OnEnable()
    {
        Collectibles.addingExperience       += AdjustExperience;
        Collectibles.addingGold             += AdjustGold;
        Collectibles.addingHealth           += AdjustHealth;
        Collectibles.addingScore            += AdjustScore;

        TrapAnimation.deathAudio            += PlayAudioClip;

        Collectibles.playCollectibleAudio   += PlayAudioClip;
    }

    private void OnDisable()
    {
        Collectibles.addingExperience       -= AdjustExperience;
        Collectibles.addingGold             -= AdjustGold;
        Collectibles.addingHealth           -= AdjustHealth;
        Collectibles.addingScore            -= AdjustScore;

        Collectibles.playCollectibleAudio   -= PlayAudioClip;      
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }


//CORE FUNCTIONS
    void AdjustExperience(float value)
    {
        _experience += value;
        //Debug.Log("Experience");
    }

    void AdjustGold(float value)
    {
        _gold += value;
        //Debug.Log("Gold");
    }

    void AdjustHealth(float value)
    {
        _health += value;
        //Debug.Log("Health");
    }

    void AdjustScore(float value)
    {
        _score += value;
        //Debug.Log("Score");
    }

    void PlayAudioClip(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
        _audioClipName = audioClip.name;
        //Debug.Log(_audioClipName);
    }
}
