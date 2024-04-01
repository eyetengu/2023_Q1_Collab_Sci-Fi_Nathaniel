using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zub_Enemy : MonoBehaviour
{
    [SerializeField] GameObject[] _zubStates;
    [SerializeField] int _stateID;
    [SerializeField] float _walkRate = .5f;
    [SerializeField] bool _increasing;
    bool _canMove;

    [SerializeField] Transform _disturbance;
    [SerializeField] private float _speed = 12;
    private float _speedMultiplier = 1.0f;
    private float _step;


    void Start()
    {
        _canMove = true;

        _disturbance = GameObject.Find("Gas").GetComponent<Transform>();
        //ZubMoving();
    }

    void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;

        ZubMoving();
        MoveTowardsDisturbance();
    }

    void ShowCurrentAnimState()
    {
        _zubStates[_stateID].SetActive(true);
    }

    void ZubMoving()
    {

        if(_canMove)
        {
            //Debug.Log("Here");
            _canMove= false;
            
            ClearAllStates();
            ChooseNextState();
            ShowCurrentAnimState();
            
            StartCoroutine(ZubWalkTimer());
        }
    }

    void ClearAllStates()
    {
        foreach (var state in _zubStates)
        {
            state.gameObject.SetActive(false);
        }
    }
    
    IEnumerator ZubWalkTimer()
    {
        //_zubStates[1].SetActive(true);
        //ClearAllStates();
        yield return new WaitForSeconds(_walkRate);
        _canMove = true;
        //ZubMoving();
    }

    void ChooseNextState()
    {
        //Debug.Log("ID " + _stateID);

        if (_increasing)
        {
            _stateID++;
            
            if (_stateID > _zubStates.Length - 1)
            { 
                _stateID = _zubStates.Length - 2; 
                _increasing= false;
            }
        }
        else
        {
            _stateID--;
            if (_stateID < 0)
            { 
                _stateID = 1;
                _increasing = true;
            }
        }
        ZubMoving();
    }

    void MoveTowardsDisturbance()
    {
        transform.position = Vector3.MoveTowards(transform.position, _disturbance.position, _step);

        RotateTowardsPlayer();
    }

    void RotateTowardsPlayer()
    {
        var targetDirection = _disturbance.position - transform.position;
        var newDirection = Vector3.MoveTowards(transform.forward, targetDirection, _step * 2);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
