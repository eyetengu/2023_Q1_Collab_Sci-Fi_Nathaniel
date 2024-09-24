using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMaker : MonoBehaviour
{
    [SerializeField] float _amplitude = 0.0f;
    [SerializeField] float _frequency = 0.0f;


    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Player Entered Asteroid Field");

        INoiseReceiver _noiseAffectsMe = other.GetComponent<INoiseReceiver>();
        if (_noiseAffectsMe != null)
            _noiseAffectsMe.EnableAsteroidFieldCameraNoise(_amplitude, _frequency);
    }

    private void OnTriggerExit(Collider other)
    {
        INoiseReceiver _noiseAffectsMeToo = other.GetComponent<INoiseReceiver>();
        if (_noiseAffectsMeToo != null)
            _noiseAffectsMeToo.EnableAsteroidFieldCameraNoise(0.0f, 0.0f);
    }
}
