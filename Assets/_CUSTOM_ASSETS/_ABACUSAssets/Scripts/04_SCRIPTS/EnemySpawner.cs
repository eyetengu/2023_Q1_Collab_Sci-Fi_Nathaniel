using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab to spawn
    public float minSpawnDelay = 10f; // Minimum delay before spawning
    public float maxSpawnDelay = 60f; // Maximum delay before spawning

    void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Generate a random delay between minSpawnDelay and maxSpawnDelay
            float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(spawnDelay);

            // Generate a random number of enemies to spawn between 1 and 3
            int numEnemies = Random.Range(1, 4);

            // Spawn the enemies
            for (int i = 0; i < numEnemies; i++)
            {
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        // Instantiate an enemy prefab at a random position within the spawner's transform
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * 5f;
        spawnPosition.y = 0f; // Ensure enemies spawn at ground level
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}