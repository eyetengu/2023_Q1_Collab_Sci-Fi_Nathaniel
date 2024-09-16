using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cd_Enemy_Movement : MonoBehaviour
{
    AudioManager_3DSpace _audioManager;
    cd_Enemy_Firing _firingScript;
    Enemy_Radar _radar;

    [Header("TARGETS")]
    [SerializeField] Transform _currentTarget;
    [SerializeField] List<Transform> _convoyTargets = new List<Transform>();

    [Header("HOME BASE")]
    [SerializeField] private Transform _homeBase;

    [Header("STATES")]
    public EnemyStates _currentState;
    public enum EnemyStates
    {
        DetermineTargets,
        EngageTarget,
        DisengageTarget,
        ReturnToBase
    }

    [Header("SPEED VALUES")]
    [SerializeField] float _speed = 3.0f;
    float _speedMultiplier = 1f;
    float _step;

    [Header("RANGES")]
    [SerializeField] float _firingRange = 5.0f;
    [SerializeField] float _disengageDistance = 3.0f;

    [Header("SCORE")]
    [SerializeField] private int _score = 1;
    [SerializeField] bool _returnToBase;

    [Header("Condition")]
    [SerializeField] bool _playerIsPriorityTarget;




//BUILT-IN FUNCTIONS
    void Start()
    {
        _audioManager = GameObject.FindObjectOfType<AudioManager_3DSpace>();
        _firingScript = GetComponent<cd_Enemy_Firing>();
        _homeBase = GameObject.Find("Bandit_Main").GetComponent<Transform>();

        FindTarget();
    }

    void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;

        //if (_currentTarget != null)
            //FindTarget();

        //DistanceChecker();
        //FSM();

        //if (_returnToBase)
            //ReturnToBase();





    }



    //The enemy should be a free-flowing character that moves from find target, engage target, attack, disengage & Return to Home Base
    //find all targets available
    //select one target
    //engage target (move/turn towards)
    //enable firing script
    //remove current target
    //disengage
    //Look For Target
    //IF ALL ELSE FAILS and no other targets then homebase is currenttarget


//RANGE FINDER
    void DistanceChecker()
    {
        if (_currentTarget == null)
            FindTarget();
        float distance = Vector3.Distance(transform.position, _currentTarget.position);
        

        if (_currentState == EnemyStates.EngageTarget)
        {
            if (_currentTarget == null)              
                _currentTarget = _radar.ReturnTargetTransform();
            
            
            else
            {
                if (distance < _firingRange && distance > _disengageDistance)
                    FireAtWill();
                if (distance < _disengageDistance)
                    _currentState = EnemyStates.DisengageTarget;
            }
        }
    }

//FINITE STATE MACHINE
    void FSM()
    {
        switch (_currentState)
        {
            case EnemyStates.DetermineTargets:
                FindTarget();
                CeaseFire();
                    break;

            case EnemyStates.EngageTarget:
                EngageTarget();
                    break;

            case EnemyStates.DisengageTarget:
                DisengageTarget();
                CeaseFire();
                break;

            case EnemyStates.ReturnToBase:
                if(_homeBase != null)
                    ReturnToBase();
                break;

            default: break;
        }
    }



    //LOCATE TARGETS
    void FindTarget()
    {
        //Clear the convoy target list (Transforms)
        _convoyTargets.Clear();

        //Create a potential target list (game objects)
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target_Enemy");

        //add potential targets to convoy target list as transforms
        if (targets.Length > 0)
        {
            foreach (var target in targets)
                _convoyTargets.Add(target.transform);
        }

        else
        {
            _currentState = EnemyStates.ReturnToBase;
            _currentTarget = _homeBase;
        }
        if (_currentTarget == null)
        {
            if (_radar != null)
            {
                _currentTarget = _radar.ReturnTargetTransform();
                if (_currentTarget == null)
                {
                    _currentTarget = _homeBase;
                    _currentState = EnemyStates.EngageTarget;
                }
            }
        }
        //_currentTarget = _convoyTargets[Random.Range(0, _convoyTargets.Count)];
        if (_currentTarget == null)
        {
            _currentState = EnemyStates.ReturnToBase;
        }
    }


    //ENGAGE TARGET
    void EngageTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _step);

        var targetDirection = _currentTarget.position - transform.position;
        var newDirection = Vector3.RotateTowards(transform.forward, targetDirection, _step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }


//FIRE AT TARGET
    void FireAtWill()
    {
        _firingScript.Firing = true;
    }
    
    
//DISENGAGE
    void CeaseFire()
    {
        _firingScript.Firing = false;
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


//RETURN TO BASE
    void ReturnToBase()
    {
        transform.position = Vector3.MoveTowards(transform.position, _homeBase.position, _step);

        var targetDirection = _homeBase.position - transform.position;
        var newDirection = Vector3.RotateTowards(transform.forward, targetDirection, _step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

}
