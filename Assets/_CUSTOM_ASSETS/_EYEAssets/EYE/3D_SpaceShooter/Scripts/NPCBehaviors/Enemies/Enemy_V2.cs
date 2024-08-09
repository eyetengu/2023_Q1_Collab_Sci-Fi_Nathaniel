using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_V2 : MonoBehaviour, IDamageable
{
    [SerializeField] private AudioManager_3DSpace _audioManager;

    float _step;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _speedMultiplier =1f;

    [SerializeField] Transform _target;

    PlayerScoreKeeper _scoreKeeper;
    [SerializeField] int _killValue = 1;
    public int Health { get; set; }
    bool _hasPlayedAudio;


    void Start()
    {
        Health = 3;

        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        _audioManager = GameObject.FindObjectOfType<AudioManager_3DSpace>();
        _scoreKeeper = GameObject.FindObjectOfType<PlayerScoreKeeper>();
    }

    void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;

        MoveTowardsTarget();
        RotateTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _step);
    }

    private void RotateTowardsTarget()
    {
        var targetDirection = _target.position - transform.position;
        var newDirection = Vector3.RotateTowards(transform.forward, targetDirection, _step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
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
