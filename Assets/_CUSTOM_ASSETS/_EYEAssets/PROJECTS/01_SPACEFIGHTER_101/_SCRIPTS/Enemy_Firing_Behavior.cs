using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Firing_Behavior : MonoBehaviour
{
    [SerializeField] Transform _gunBarrel;
    [SerializeField] GameObject _laserPrefab;
    [SerializeField] Transform _ammoPouch;

    [SerializeField] bool _tripleShot;
    [SerializeField] float _firingDelay = 1.5f;
    bool _canFire = true;


//CORE FUNCTIONS
    public void FireLaser()
    {
        if (_canFire)
        {
            _canFire = false;
            
            if (_tripleShot) 
            {
                StartCoroutine(TripleShotTimer());
            }
            else
            {
                var laser = Instantiate(_laserPrefab, _gunBarrel.position, Quaternion.identity);
                laser.transform.SetParent(_ammoPouch);
                StartCoroutine(FireDelay());
            }
        }
    }


//COROUTINES
    IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(_firingDelay);
        
        _canFire = true;
    }

    IEnumerator TripleShotTimer()
    {
        for(int i = 0;i < 3;i++) 
        {
            var laser = Instantiate(_laserPrefab, _gunBarrel.position, _gunBarrel.rotation);
            yield return new WaitForSeconds(0.25f);
        }

        yield return new WaitForSeconds(_firingDelay);
        
        _canFire = true;
    }
}
