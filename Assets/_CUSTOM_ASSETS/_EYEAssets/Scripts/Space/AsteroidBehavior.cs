using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] float _minSpinSpeed = 1f;
    [SerializeField] float _maxSpinSpeed = 5f;
    [SerializeField] float _minThrust = 0.1f;
    [SerializeField] float _maxThrust = 0.5f;
    private float _spinSpeed;

    [SerializeField] GameObject _asteroidField;

    void Start()
    {
        _asteroidField = GameObject.FindObjectOfType<GenerateAsteroidField>().gameObject;
        _rb = GetComponent<Rigidbody>();

        transform.SetParent(_asteroidField.transform);

        _spinSpeed = Random.Range(_minSpinSpeed, _maxSpinSpeed);
        float thrust = Random.Range(_minThrust, _maxThrust);

        _rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
    }

    void Update()
    {
        transform.Rotate(Vector3.up, _spinSpeed * Time.deltaTime);
    }
}
