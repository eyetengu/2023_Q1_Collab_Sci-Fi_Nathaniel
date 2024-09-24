using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CollectableBehavior : MonoBehaviour
{
    [SerializeField] AudioManager_3DSpace _audioManager;

    float _step;
    [SerializeField] float _speed = -3f;
    [SerializeField] float _speedMultiplier = 1f;

    [SerializeField] float _upperSpawnPoint = 40f;
    [SerializeField] float _lowerSpawnPoint = -45f;
    bool _isCollected;


    public int Health { get; set; }

    void Start()
    {
        Health = 3;
    }

    void FixedUpdate()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime * -1;
        FallingObjectMovement();
        FallingObjectBoundaryBehavior();
    }

    void FallingObjectMovement()
    {
        transform.Translate(new Vector3(0, 0, _step));
    }

    void FallingObjectBoundaryBehavior()
    {
        if (transform.position.z < _lowerSpawnPoint)
            transform.position = new Vector3(Random.Range(-20f, 20f), 0, _upperSpawnPoint);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Player Detected");
            if (_isCollected == false)
            {
                _isCollected = true;
                
                ICanCollect _collector = other.GetComponent<ICanCollect>();
                
                if(_collector != null)
                    _collector.PassItemInfo(Health);
                
                if(_audioManager != null)
                    _audioManager.PickupAudio();

                gameObject.SetActive(false);
            }
        }
    }

}
