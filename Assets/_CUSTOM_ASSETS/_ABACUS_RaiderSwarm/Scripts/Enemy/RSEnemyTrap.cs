using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSEnemyTrap : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemySpawns;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == RSPlayer.Instance.gameObject)
        {
            foreach(var trap in _enemySpawns)
            {
                var spawner = trap.GetComponent<RSEnemySpawner>();
                spawner.SpawnEnemy();
            }
            gameObject.SetActive(false);
        }
    }
}
