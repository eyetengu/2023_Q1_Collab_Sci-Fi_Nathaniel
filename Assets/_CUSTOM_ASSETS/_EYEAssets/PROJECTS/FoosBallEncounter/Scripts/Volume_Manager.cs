using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class Volume_Manager : MonoBehaviour
{
    [Header("VOLUME OBJECTS")]
    [SerializeField] GameObject _globalVolumeObject;
    [SerializeField] GameObject _boxVolumeObject;

    [Header("COMPONENTS")]
    [SerializeField] Volume _volumeComponent;

    [Header("PROFILES")]
    [SerializeField] VolumeProfile _volumeProfile;


    void Start()
    {
    }

    void Update()
    {
        //_volumeComponent = _globalVolumeObject.GetComponent<Volume>();
        _volumeComponent = _boxVolumeObject.GetComponent<Volume>();
            
        _volumeProfile = _volumeComponent.profile;
        
        Debug.Log(_volumeComponent.ToString());
        Debug.Log(_volumeProfile.ToString());        
    }
}
