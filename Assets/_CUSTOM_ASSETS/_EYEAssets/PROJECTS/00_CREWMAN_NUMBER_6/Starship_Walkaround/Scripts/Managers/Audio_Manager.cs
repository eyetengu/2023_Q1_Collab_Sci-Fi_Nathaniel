using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _ambianceSource;
    [SerializeField] private AudioSource _generalSource;

    int _musicTrackID;
    [SerializeField] private AudioClip[] _musicClips;
    //Fantasy Victory
    //Hot Pepper
    //Epic Trailer
    //Tropical Moments
    //The Afterparty
    [SerializeField] private AudioClip[] _ambianceClips;
    //Sci-Fi Ambiance
    [SerializeField] private AudioClip[] _generalClips;
    //Door Squeak
    //Door Close
    //HitsAccept
    //Monster Scream
    //Congratulations
    //Victory
    //Xylo
    //Male Scream
    //Bullet Ricochet

    [SerializeField] private AudioClip[] _exertionAndDeathSounds;
    [SerializeField] private AudioClip[] _gameConditions;


    private void Start()
    {
        _musicSource.volume = 0.064f;
        _ambianceSource.volume = 0.134f;
        _generalSource.volume = 0.235f;

        PlayMusicTrack();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))        
            SelectNextMusicTrack();        
    }

    void SelectNextMusicTrack()
    {
        _musicTrackID++;
        if (_musicTrackID > _musicClips.Length - 1)
            _musicTrackID = 0;

        PlayMusicTrack();
    }

    void PlayMusicTrack()
    {
        _musicSource.PlayOneShot(_musicClips[_musicTrackID]);
    }

    void PlayAmbianceTrack(int trackID)
    {
        _ambianceSource.PlayOneShot(_ambianceClips[trackID]);
    }

    public void PlayGeneralTrack(int trackID)
    {
        _generalSource.PlayOneShot(_generalClips[trackID]);
    }

    public void PlayBulletRicochet()
    {
        _generalSource.PlayOneShot(_generalClips[0]);
    }
}
