using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetoidBehavior : MonoBehaviour
{
    float _step;
    [SerializeField] float _speed = -3f;
    [SerializeField] float _speedMultiplier = 1f;

    [SerializeField] float _upperSpawnPoint = 10f;
    [SerializeField] float _lowerSpawnPoint = -10f;

    private MeshRenderer _renderer;
    [SerializeField] private Material[] _planetMaterials;


    private void Start()
    {
        _renderer = GetComponentInChildren<MeshRenderer>();
    }

    void FixedUpdate()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime * -1;
        FallingObjectMovement();
        FallingObjectBoundaryBehavior();
        RotatePlanetoid();
    }

    void RotatePlanetoid()
    {
        transform.Rotate(.1f, .1f, .1f);
    }

    void FallingObjectMovement()
    {
        transform.Translate(new Vector3(0, 0, _step));
    }

    void FallingObjectBoundaryBehavior()
    {
        if (transform.position.z < _lowerSpawnPoint)
        { 
            transform.position = new Vector3(Random.Range(-20f, 20f), 0, _upperSpawnPoint);
            PlanetoidSwitch();
        }
    }

    void PlanetoidSwitch()
    {
        _renderer.material = _planetMaterials[Random.Range(0, _planetMaterials.Length-1)];
    }
}
