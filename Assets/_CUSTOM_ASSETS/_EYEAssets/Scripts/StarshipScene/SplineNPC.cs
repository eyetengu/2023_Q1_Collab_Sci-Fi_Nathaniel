using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineNPC : MonoBehaviour
{
    Animator _animator;
    SplineAnimate _spline;
    float _originalSplineDuration;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _spline = GetComponent<SplineAnimate>();    
        _originalSplineDuration = _spline.Duration;
        _animator.SetBool("Walk", true);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "TriggerCube")
        {
            Debug.Log("IN");
            _spline.enabled= false;
            StartCoroutine(StationTimer());
            transform.rotation = other.transform.rotation;
            _animator.SetBool("Walk", false);
        }
    }

    IEnumerator StationTimer()
    {
        yield return new WaitForSeconds(3f);
        _spline.enabled = true;
        _animator.SetBool("Walk", true);
    }
}
