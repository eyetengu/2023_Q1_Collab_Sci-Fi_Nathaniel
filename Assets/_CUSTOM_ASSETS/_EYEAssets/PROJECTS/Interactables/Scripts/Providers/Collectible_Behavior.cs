using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Behavior : MonoBehaviour
{
    AudioPlayer _audioPlayer;

    [SerializeField] bool _experience;
    [SerializeField] bool _gold;
    [SerializeField] bool _score;

    [SerializeField] int _value;
    SphereCollider _collider;


//BUILT-IN FUNCTIONS
    private void Start()
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _collider = GetComponent<SphereCollider>();    
    }


//TRIGGER FUNCTIONS
    private void OnTriggerEnter(Collider other)
    {
        var collector = other.GetComponent<Player_Collection>();
        if(collector != null)
        {
            Debug.Log("Collecting Item");

            if (_experience) { collector.IncreaseExperience(_value); }
            else if(_gold) { collector.IncreaseGold(_value); }
            else if(_score) { collector.IncreaseScore(_value); } 

            _audioPlayer.PlayPickup();
            _collider.enabled = false;
            StartCoroutine(CollectibleResetTimer());
        }
    }


//COROUTINES
    IEnumerator CollectibleResetTimer()
    {
        yield return new WaitForSeconds(0.2f);
        _collider.enabled = true;
        gameObject.SetActive(false);
    }
}
