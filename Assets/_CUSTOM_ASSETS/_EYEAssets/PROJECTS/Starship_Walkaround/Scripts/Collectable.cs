using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] bool _experience, _gold, _health, _score;
    [SerializeField] int _value;
    string _valueType;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;




//BUILT-IN FUNCTIONS
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ICanCollect _collector  = other.GetComponent<ICanCollect>();

            if(_collector != null)
            {
                if (_experience)
                    _valueType = "exp";
                else if (_gold)
                    _valueType = "gol";
                else if (_health)
                    _valueType = "hea";
                else if (_score)
                    _valueType = "sco";
            }
                _collector.PassValueToGenEx(_value, _valueType);
            _audioSource.PlayOneShot(_audioClip);
            Destroy(gameObject, 1.0f);
        }    
    }










}
