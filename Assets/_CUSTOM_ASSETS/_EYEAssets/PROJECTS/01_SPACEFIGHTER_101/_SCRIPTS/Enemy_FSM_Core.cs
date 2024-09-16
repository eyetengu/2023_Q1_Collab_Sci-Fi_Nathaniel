using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_FSM_Core : MonoBehaviour
{
    Enemy_Movement  _movementScript;    

    public enum EnemyStates {  EngagedWithEnemy, Patrolling }
    public EnemyStates _currentState;

    [Header("TARGETS")]
    [SerializeField] Transform _homeTransform;
    [SerializeField] Transform _targetTransform;
    [SerializeField] Transform _currentTarget;

    [Header("RANGES")]
    [SerializeField] float _distance;
    [SerializeField] float _targetingRange = 300;
        

//BUILT-IN FUNCTIONS
    private void Start()
    {
        _currentTarget = _targetTransform;
        _movementScript = GetComponent<Enemy_Movement>();
    }

    void Update()
    {
        DistanceChecker();
        EnemyFSM();
    }


    //CORE FUNCTIONS
    void DistanceChecker()
    {
        if (_currentTarget != null)
        {
            _distance = Vector3.Distance(transform.position, _currentTarget.position);

            if (_distance >= _targetingRange)
                _currentState = EnemyStates.Patrolling;
            else if (_distance < _targetingRange)
                _currentState = EnemyStates.EngagedWithEnemy;
        }
    }

    void EnemyFSM()
    {
        switch (_currentState)
        {
            case EnemyStates.EngagedWithEnemy:
                Debug.Log("Engaging");
                _movementScript.TargetInSights = true;
                break;

            case EnemyStates.Patrolling:
                Debug.Log("Patrolling");
                _movementScript.TargetInSights = false;
                _movementScript.SetCourseForHome();
                break;

            default:
                break;
        }
    }
}

///
///A full intro sequence has been tailored(can be tweaked in the future. This is a prototype)
///To accomodate this, several systems had to be created:Camera manager, spawn manager, enemy movement, enemy health, Level, Skybox and Scene Managers
///The intro scene zooms in on the player while displaying the game name
///while the messages roll out the player controls are turned on and the player may move about the scene
///The camera takes a wider view of the situation showing the enemies that have entered the area and then returns to the game view camera
///The player is able to move freely.The Wave Manager may be working correctly. double check
///
/// 
///enemy motion appears to be jerky. adjust as needed.cannot destroy enemies
///goal: destroy enemies and move to next round/levelmaybe the skybox stays the same for four rounds
///There could be four backgrounds that could rotate through on each skybox.
///At that time the skyboxes might be unlocked and the skybox selection becomes randomized.

