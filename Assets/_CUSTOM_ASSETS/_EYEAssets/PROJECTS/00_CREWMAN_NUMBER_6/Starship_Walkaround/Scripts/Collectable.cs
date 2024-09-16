using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    Audio_Manager _audioManager;

    [SerializeField] bool _experience, _gold, _health, _score;
    [SerializeField] int _value;
    string _valueType;


    //BUILT-IN FUNCTIONS
    void Start()
    {
        _audioManager = FindObjectOfType<Audio_Manager>();   
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

            _audioManager.PlayGeneralTrack(4);

            Destroy(gameObject, 1.0f);
        }    
    }
}
