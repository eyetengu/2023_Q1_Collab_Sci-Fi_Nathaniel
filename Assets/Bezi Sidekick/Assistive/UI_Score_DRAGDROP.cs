using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Score_DRAGDROP : MonoBehaviour
{
    AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;
    int _score;
    [SerializeField] int _scoreToWin = 9;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Score()
    {
        _score++;
    
        if(_score == _scoreToWin)
        {
            _audioSource.PlayOneShot(_audioClip);
        }
            
        
        Debug.Log("SCORE: " +_score);
    }
}
