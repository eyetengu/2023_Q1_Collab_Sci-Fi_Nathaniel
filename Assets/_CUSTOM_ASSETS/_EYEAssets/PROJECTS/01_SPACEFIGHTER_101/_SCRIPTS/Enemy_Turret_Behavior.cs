using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Turret_Behavior : MonoBehaviour
{
    //TURRET BEHAVIOR
    [Header("BARREL & BULLETS")]
    [SerializeField] Transform _gunBarrel;
    [SerializeField] Transform _turretBase;
    [SerializeField] Transform _ammoPouch;
    [SerializeField] GameObject _laserPrefab;
    [SerializeField] float _fireDelay = 3.0f;
    bool _canFire;

    [Header("TARGET")]
    [SerializeField] Transform _targetTransform;

    [SerializeField] float _speed = 5.0f;
    float _step;
    [SerializeField] bool _multiFire = true;
    [SerializeField] int _multiFireCount = 3;

    [SerializeField] bool _autoFire;   

    public Transform TargetTransform { get => _targetTransform; set => _targetTransform = value; }


    //BUILT-IN FUNCTIONS
    void Start()
    {
        _canFire = true;
    }

    void Update()
    {
        _step = _speed * Time.deltaTime;

        //if (_canFire) 
        {
            if (Input.GetKeyDown(KeyCode.Space))           
                FiringOrders();                           

            if (_autoFire)            
                FiringOrders();            
        }

        //TurnBarrelToFaceTarget();
    }

    public void FiringOrders()
    {
        if (_canFire)
        {
            _canFire = false;

            if (_multiFire)
                StartCoroutine(MultiFireTimer());
            else
                StartCoroutine(SingleFireTimer());
        }
    }

//CORE FUNCTIONS
    public void TurnBarrelToFaceTarget()
    {
        //the y value will be unlimited
        //the x value will be the x axis rotation of the turret
        //the z value will be unused.

        Vector3 targetDirection = TargetTransform.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(_turretBase.forward, targetDirection, _step, 0.0f);
        _turretBase.transform.rotation = Quaternion.LookRotation(newDirection);
    }
    
     void CreateBullet()
    {
        var bullet = Instantiate(_laserPrefab, _gunBarrel.transform.position, _gunBarrel.rotation);
        bullet.transform.SetParent(_ammoPouch);
    }


//COROUTINES
    IEnumerator SingleFireTimer()
    {
        CreateBullet();
        yield return new WaitForSeconds(_fireDelay);
        _canFire = true;
    }

    IEnumerator MultiFireTimer()
    {
        for (int i = 0; i < 3; i++)
        {
            CreateBullet();
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(_fireDelay);
        _canFire = true;
    }
}
