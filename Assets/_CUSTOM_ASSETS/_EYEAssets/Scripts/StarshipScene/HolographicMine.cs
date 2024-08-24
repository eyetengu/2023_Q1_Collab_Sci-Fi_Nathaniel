using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolographicMine : MonoBehaviour
{
    [SerializeField] private Transform[] _reticles;

    float _step;
    [SerializeField] float _speed = 3;
    float _speedMultiplier = 1;
    [SerializeField] float _delayTime = 3f;


    void Start()
    {
        StartCoroutine(ReverseTimer());
        Debug.Log(_reticles.Length);
    }


    void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;

        ReticleBehavior();

        if (Input.GetKey(KeyCode.I))
            InitiateRedReticles(true);
        else
            InitiateRedReticles(false);

    }

    void MineHover()
    {

    }

    void InitiateRedReticles(bool value)
    {
        foreach(var reticle in _reticles)
        {
            var renderer = reticle.gameObject.GetComponent<MeshRenderer>();
            if(value)
                renderer.material.color = Color.red;

            else
                renderer.material.color = Color.green;
        }
    }

    void ReticleBehavior()
    {
        Debug.Log(_reticles.Length);

        _reticles[0].Rotate(0, 0, _step);   
        _reticles[2].Rotate(0, 0, _step);

        _reticles[1].Rotate(0, 0, -_step);
        _reticles[3].Rotate(0, 0, -_step);
    }

    void SwitchDirection()
    {
        StartCoroutine(ReverseTimer());
    }

    IEnumerator ReverseTimer()
    {
        yield return new WaitForSeconds(_delayTime);
        _speedMultiplier *= -1;
        SwitchDirection();
    }
}
