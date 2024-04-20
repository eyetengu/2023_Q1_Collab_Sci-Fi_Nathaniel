using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    public float playerDetectionRadius = 25f;
    public Transform player;
    NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > playerDetectionRadius)
        {
            // Find the closest enemySpawner and move around it
            Transform closestSpawner = FindClosestSpawner();
            if (closestSpawner == null)
            {
                return;
            }
            navMeshAgent.SetDestination(RandomNavmeshLocation(closestSpawner.position, 10f));
        }
        else
        {
            // Move towards the player using NavMesh
            navMeshAgent.SetDestination(player.position);
        }
    }
   
    // Function to find the closest enemySpawner
    Transform FindClosestSpawner()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        Transform closestSpawner = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject spawner in spawners)
        {
            float distance = Vector3.Distance(transform.position, spawner.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestSpawner = spawner.transform;
            }
        }

        return closestSpawner;
    }

    // Function to find a random point within a given radius on the NavMesh
    Vector3 RandomNavmeshLocation(Vector3 origin, float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += origin;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas);
        return hit.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}