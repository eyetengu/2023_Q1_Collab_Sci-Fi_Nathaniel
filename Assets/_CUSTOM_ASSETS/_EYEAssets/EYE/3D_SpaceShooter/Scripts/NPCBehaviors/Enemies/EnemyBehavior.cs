using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour, IDamageable
{
    [SerializeField] private AudioManager_3DSpace _audioManager;
    float _step;
    [SerializeField] float _speed = -3f;
    [SerializeField] float _speedMultiplier = 1f;

    [SerializeField] float _upperSpawnPoint = 7f;
    [SerializeField] float _lowerSpawnPoint = -7f;
    bool _hasPlayedAudio;

    PlayerScoreKeeper _scoreKeeper;
    [SerializeField] int _killValue = 1;


    public int Health { get; set; }

    void Start()
    {
        Health = 3;
        
        _audioManager = GameObject.FindObjectOfType<AudioManager_3DSpace>();
        _scoreKeeper = GameObject.FindObjectOfType<PlayerScoreKeeper>();
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
        if (other.tag == "Projectile")
        {
            Debug.Log("Ouch");
            Damage(1);
        }
    }

    public void Damage(int damageAmount)
    {
        Health -= damageAmount;
        if (Health <= 0)
        {
            if (_hasPlayedAudio == false)
            {
                _hasPlayedAudio = true;
                
                _scoreKeeper.UpdateScore(_killValue);
                _audioManager.ExplosionAudio();
                gameObject.SetActive(false);
            }
        }
    }
}
