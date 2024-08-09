using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class Enemy_V3 : MonoBehaviour, IDamageable
{
    AudioManager_3DSpace _audioManager;

    List<Transform> _convoyTargets= new List<Transform>();
    Transform _currentTarget;
    public enum EnemyStates {   DetermineTargets,
                                SelectTarget,
                                EngageTarget,
                                DisengageTarget,
                                ReturnToBase    }
    public EnemyStates _currentState;

    float _step;
    [SerializeField] float _speed = 3.0f;
    float _speedMultiplier = 1f;
    [SerializeField] float _firingRange = 5.0f;
    [SerializeField] float _disengageDistance = 3.0f;


    float _fireRate = 0.5f;
    float _canFire = 1.0f;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private Transform _homeBase;
    [SerializeField] private Transform _gunBarrel;

    [SerializeField] private GameObject _bulletFX;
    [SerializeField] private GameObject _fireFX;
    [SerializeField] private GameObject _explosionFX;
    [SerializeField] private int _score = 1;

    void Start()
    {
        _audioManager = GameObject.FindObjectOfType<AudioManager_3DSpace>();
        _homeBase = GameObject.Find("Bandit_Main").GetComponent<Transform>();
        Health = 5;
    }

    void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;

        FSM();
    }

    void FSM()
    {
        switch(_currentState )
        {
            case EnemyStates.DetermineTargets:
                FindSuitableTargets();
                break;
            case EnemyStates.SelectTarget:
                break;
            case EnemyStates.EngageTarget:
                EngageTarget();
                DistanceChecker();
                break;
            case EnemyStates.DisengageTarget:
                DisengageTarget();
                break;
            case EnemyStates.ReturnToBase: 
                ReturnToBase();
                break;
        }
    }

    //CORE FUNCTIONS
    void FindSuitableTargets()
    {
        _convoyTargets.Clear();

        var targets = GameObject.FindGameObjectsWithTag("Target_Enemy");
        if (targets.Length > 0)
        {
            foreach (var target in targets)
            {
                _convoyTargets.Add(target.transform);
            }
            _currentTarget = _convoyTargets[Random.Range(0, _convoyTargets.Count)];

            _currentState = EnemyStates.EngageTarget;

        }
        else
            _currentState = EnemyStates.ReturnToBase;
    }

    void DistanceChecker()
    {
        var distance = Vector3.Distance(transform.position, _currentTarget.position);
        if(distance < _firingRange && _currentState == EnemyStates.EngageTarget)
        {
            FireAtWill();
        }

        if(distance < _disengageDistance && _currentState == EnemyStates.EngageTarget)
        {
            _currentState = EnemyStates.DisengageTarget;
        }
    }

    void EngageTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _step);

        var targetDirection = _currentTarget.position - transform.position;
        var newDirection = Vector3.RotateTowards(transform.forward, targetDirection, _step, 0.0f);
        transform.rotation= Quaternion.LookRotation(newDirection);
    }

    void FireAtWill()
    {
        if(Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, _gunBarrel.position, _gunBarrel.rotation);
        }
    }

    void DisengageTarget()
    {
        transform.Translate(new Vector3(0, 0, 4 * _step));
        transform.Rotate(0, 4 * _step, 0);

        StartCoroutine(DisengageTimer());
    }

    IEnumerator DisengageTimer()
    {
        yield return new WaitForSeconds(3);
        _currentState = EnemyStates.DetermineTargets;
    }

    void ReturnToBase()
    {
        transform.position = Vector3.MoveTowards(transform.position, _homeBase.position, _step);

        var targetDirection = _homeBase.position - transform.position;
        var newDirection = Vector3.RotateTowards(transform.forward, targetDirection, _step, 0.0f);
        transform.rotation= Quaternion.LookRotation(newDirection);
    }

    //HEALTH
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Projectile")
        {
            Damage(1);
            _bulletFX.SetActive(true);
            StartCoroutine(BulletFXTimer());
            _audioManager.PlayBulletMetalRicochet();

            if(Health <= 0)
            {
                _fireFX.SetActive(false);
                _bulletFX.SetActive(false);
                _explosionFX.SetActive(true);

                StartCoroutine(DisableCraftTimer());
                GameManager.Instance.GetComponent<ScoreManager>().SetScore(_score);
            }
            if(Health <= 3)
            {
                _fireFX.SetActive(true);
            }
        }
    }
    
    IEnumerator DisableCraftTimer()
    {
        yield return new WaitForSeconds(1.0f);
        this.gameObject.SetActive(false);
    }

    IEnumerator BulletFXTimer()
    {
        yield return new WaitForSeconds(.15f);
        _bulletFX.SetActive(false);
    }

    public int Health { get; set; }

    public void Damage(int damageAmount)
    {
        Health -= damageAmount;
    }

}
