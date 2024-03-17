using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Behavior : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _turretTransform;
    [SerializeField] private GameObject _barrelA;
    [SerializeField] private GameObject _barrelB;

    [SerializeField] bool _canFire;
    [SerializeField] bool _isAlternating;

    [SerializeField] Transform _turretBatteryA;
    [SerializeField] Transform _turretBatteryB;

    [SerializeField] float _recoilDelay = .15f;
    [SerializeField] float _fireDelay = .23f;

    private float _rotateYMultiplier = -1f;

    [SerializeField] Transform _lRecoilLimit;
    [SerializeField] Transform _rRecoilLimit;

    [SerializeField] Transform _lRestLimit;
    [SerializeField] Transform _rRestLimit;

    [SerializeField] Transform _ammoPouch;


    void Start()
    {
        SetCursorLockState();
        _canFire = true;
    }


void SetCursorLockState()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible= false;
    }

    void SetCursorUnlockState()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void SetConfinedCursorState()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))        
            SetCursorUnlockState();
        

        TurretRotation();

        //Debug.Log("Bookmark");


        if (Input.GetMouseButton(0))
        {
            if (_canFire)
            {
                _canFire = false;

                if (_isAlternating)
                    StartCoroutine(AlternatingFireTimer());
                else
                {
                    StartCoroutine(TandemFiringTimer());
                    Instantiate(_projectilePrefab, _turretBatteryB.position, _turretBatteryB.rotation);
                    Instantiate(_projectilePrefab, _turretBatteryA.position, _turretBatteryA.rotation);
                    StartCoroutine(CooldownTimer());
                }
            }
        }
    }

    void TurretRotation()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        transform.Rotate(0, mouseX, 0);
        _turretTransform.Rotate(mouseY * _rotateYMultiplier, 0, 0);

    }

    void GunBarrelRecoil_A()
    {
        StartCoroutine(RecoilTimer());
    }

    IEnumerator RecoilTimer()
    {
        _barrelA.transform.position = _lRecoilLimit.position;
        _barrelB.transform.position = _rRecoilLimit.position ;
        GunBarrelRecoil_A();
        yield return new WaitForSeconds(_recoilDelay);
        _barrelA.transform.position = _lRestLimit.position;
        _barrelB.transform.position = _rRestLimit.position ;
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(_fireDelay);
        _canFire= true;
    }

    IEnumerator TandemFiringTimer()
    {
        _barrelA.transform.position = _lRecoilLimit.position;
        _barrelB.transform.position = _rRecoilLimit.position;

        yield return new WaitForSeconds(_fireDelay/2);

        _barrelA.transform.position = _lRestLimit.position;
        _barrelB.transform.position = _rRestLimit.position;
    }

    IEnumerator AlternatingFireTimer()
    {
        var bulletA = Instantiate(_projectilePrefab, _turretBatteryB.position, _turretBatteryB.rotation);
        bulletA.transform.SetParent(_ammoPouch);

        _barrelB.transform.position = _rRecoilLimit.position;
        yield return new WaitForSeconds(_fireDelay / 2);
        _barrelB.transform.position = _rRestLimit.position;

        yield return new WaitForSeconds(_fireDelay/2);

        var bulletB = Instantiate(_projectilePrefab, _turretBatteryA.position, _turretBatteryA.rotation);
        bulletB.transform.SetParent(_ammoPouch);
        _barrelA.transform.position = _lRecoilLimit.position;

        yield return new WaitForSeconds(_fireDelay/2);

        _barrelA.transform.position = _lRestLimit.position;

        yield return new WaitForSeconds(_fireDelay / 2);

        _canFire = true;
    }
}
