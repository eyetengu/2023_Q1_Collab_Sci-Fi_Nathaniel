using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Behavior : MonoBehaviour
{
    [Header("SPEED VALUES")]
    [SerializeField] private float _speed = 15.0f;
    [SerializeField] private float _speedBoost = 1.0f;
    private float _step;

    [Header("EVENTS")]
    [SerializeField] bool _timed;
    [SerializeField] bool _explosive;
    [SerializeField] bool _speedBoosters;

    [Header("EXPLOSIVE OPTIONS")]
    [SerializeField] bool _proximity;
    [SerializeField] bool _contact ;
    bool _activateSpeedBoost;
    bool _isTraveling;
    bool _hasDetonated;
    [SerializeField] float _laserLifeDelay = 4.0f;
    [SerializeField] float _eventDelay = 1.2f;
    [SerializeField] GameObject _explosionPrefab;
    [SerializeField] Transform _ammoPouch;
    [SerializeField] Transform _explosionPouch;


    void Start()
    {
        //transform.SetParent(_ammoPouch);

        if (_timed)
            StartCoroutine(TimedEvent());
        else
            StartCoroutine(LaserLifeTimer());
    }

    void Update()
    { 
        _step = _speed * _speedBoost * Time.deltaTime;

        if (_activateSpeedBoost)
            _speedBoost = 5.0f;
            
        transform.Translate(new Vector3(0, 0, _step));
    }

    //TRIGGER FUNCTIONS
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            var explosion = Instantiate(_explosionPrefab, transform.position, other.transform.rotation);
            explosion.transform.SetParent(_explosionPouch);
            gameObject.SetActive(false);
        }
    }



    //COROUTINES
    IEnumerator LaserLifeTimer()
    {
        yield return new WaitForSeconds(_laserLifeDelay);
        this.gameObject.SetActive(true);
    }

    IEnumerator TimedEvent()
    {
        yield return new WaitForSeconds(_eventDelay);
        
        if (_explosive)
            _explosionPrefab.SetActive(true);

        if (_speedBoosters)
        {
            _speedBoost = 2.0f;
            yield return new WaitForSeconds(0.3f);
            _activateSpeedBoost = true;
        }
    }
}
