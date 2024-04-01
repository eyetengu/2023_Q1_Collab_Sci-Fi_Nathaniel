using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZubSpawner : MonoBehaviour
{
    private float _spawnRate = 1.5f;
    [SerializeField] private GameObject _zubPrefab;
    private bool _readyToSpawn;
    [SerializeField] private Transform _zubParent;
    [SerializeField] private Transform _spawnLocation;
    private int _zubMax;
    private int _zubCount;

    void Start()
    {
        _readyToSpawn= true;
        _zubMax = 3;
    }

    void Update()
    {
        if(_readyToSpawn && _zubCount < _zubMax)
        {
            _zubCount++;
            _readyToSpawn = false;
            StartCoroutine(SpawnRateTimer());
        }
    }

    IEnumerator SpawnRateTimer()
    {
        yield return new WaitForSeconds(_spawnRate);
        var zubOffspring = Instantiate(_zubPrefab, _spawnLocation.position, Quaternion.identity);
        zubOffspring.transform.SetParent(_zubParent.transform,true);
        _readyToSpawn = true;
    }
}
