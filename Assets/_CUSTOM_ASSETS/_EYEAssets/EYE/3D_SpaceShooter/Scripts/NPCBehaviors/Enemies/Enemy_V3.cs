using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class Enemy_V3 : MonoBehaviour
{
    AudioManager_3DSpace _audioManager;

    [Header("TRANSFORMS")]
    [SerializeField] List<Transform> _convoyTargets= new List<Transform>();
    [SerializeField] private Transform _homeBase;
    [SerializeField] Transform _currentTarget;

    [Header("STATES")]
    public EnemyStates _currentState;
    public enum EnemyStates {   DetermineTargets,
                                SelectTarget,
                                EngageTarget,
                                DisengageTarget,
                                ReturnToBase            }

    [Header("SPEED VALUES")]
    [SerializeField] float _speed = 3.0f;

    [Header("DISTANCE & RANGE")]
    [SerializeField] float _firingRange = 5.0f;
    [SerializeField] float _disengageDistance = 3.0f;

    [Header("SCORING")]
    [SerializeField] private int _score = 1;

    float _step;
    float _speedMultiplier = 1f;
    

    void Start()
    {
        _audioManager = GameObject.FindObjectOfType<AudioManager_3DSpace>();
        _homeBase = GameObject.Find("Bandit_Main").GetComponent<Transform>();
        _currentState = EnemyStates.DetermineTargets;   
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
        //if(distance < _firingRange && _currentState == EnemyStates.EngageTarget)
        //{
            //FireAtWill();
        //}

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

}
