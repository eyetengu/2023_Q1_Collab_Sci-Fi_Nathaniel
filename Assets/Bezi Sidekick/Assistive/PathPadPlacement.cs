using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPadPlacement : MonoBehaviour
{
    [SerializeField] int _height = 3;
    [SerializeField] int _width = 2;
    Vector3 _spawnOrigin = new Vector3(0, 0, 0);
    [SerializeField] GameObject _tilePrefab;


    void Start()
    {
        PlacePads();
    }


    void Update()
    {
        
    }

    void PlacePads()
    {
        for(int i = 0; i < _width;i ++)
        {
            for(int j = 0; j < _height; j++)
            {
                var tile = Instantiate(_tilePrefab, transform.position + _spawnOrigin, Quaternion.identity);
                _spawnOrigin += new Vector3(1.5f, 0, 0);
            }
            _spawnOrigin = new Vector3(0, 0, 1.5f);
        }
    }
}
