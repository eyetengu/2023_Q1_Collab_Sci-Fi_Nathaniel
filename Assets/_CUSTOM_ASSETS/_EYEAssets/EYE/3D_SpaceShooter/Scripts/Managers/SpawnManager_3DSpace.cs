using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_3DSpace : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Transform _enemyContainer;


    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
   
    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-20f, 20f), 0, 20);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer;
            yield return new WaitForSeconds(5.0f);
        }
    }
}
