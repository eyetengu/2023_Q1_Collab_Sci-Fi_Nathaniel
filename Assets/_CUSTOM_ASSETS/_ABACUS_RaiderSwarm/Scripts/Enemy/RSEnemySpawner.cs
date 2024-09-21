using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyGameObject;
    public void SpawnEnemy()
    {
        Instantiate(_enemyGameObject, transform);
    }
}
