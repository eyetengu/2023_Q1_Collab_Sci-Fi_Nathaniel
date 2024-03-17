using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAsteroidField : MonoBehaviour
{
    [SerializeField] Transform _asteroidPrefab;
    [SerializeField] int _fieldRadius = 1;
    [SerializeField] int _asteroidCount = 1000;

    
    void Start()
    {
        for(int i = 0; i < _asteroidCount; i++)
        {
            Instantiate(_asteroidPrefab, Random.insideUnitSphere * _fieldRadius, Quaternion.identity);
        }           
    }
}
