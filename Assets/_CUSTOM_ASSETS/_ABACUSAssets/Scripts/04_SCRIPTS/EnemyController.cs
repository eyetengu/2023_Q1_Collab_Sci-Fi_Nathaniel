using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float playerDetectionRadius = 25f;
    public Transform player;
    public int Damage = 1;
    NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        var playerTag = GameObject.FindGameObjectWithTag("Player");
        if (playerTag != null)
        {
            player = playerTag.transform;
        }
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > playerDetectionRadius)
        {
            List<Transform> list = new List<Transform>();
            Transform closestGasDrill = FindClosestTaggedObject(Tags.Gas.ToString());
            if (closestGasDrill != null && closestGasDrill.GetComponent<TruckDetector>().IsActiveDrill)
            {
            list.Add(closestGasDrill);
            }
            Transform closestOreDrill = FindClosestTaggedObject(Tags.Ore.ToString());
            if (closestOreDrill != null && closestOreDrill.GetComponent<TruckDetector>().IsActiveDrill)
            {
                list.Add(closestOreDrill);
            }
            Transform closestCrystalDrill = FindClosestTaggedObject(Tags.Crystal.ToString());
            if (closestCrystalDrill != null && closestCrystalDrill.GetComponent<TruckDetector>().IsActiveDrill)
            {
                list.Add(closestCrystalDrill);
            }
            Transform closestSpawner;
            if (list.Count > 0)
            {
                SortTransformsByDistance(list, transform);
                closestSpawner = list.FirstOrDefault();
            }
            else
            {
                closestSpawner = FindClosestTaggedObject(Tags.EnemySpawner.ToString());
            }
            if (closestSpawner != null)
            {
                navMeshAgent.SetDestination(RandomNavmeshLocation(closestSpawner.position, 10f));
            }
            else
            {
                //Just keep attacking player
                navMeshAgent.SetDestination(player.position);
            }
        }
        else
        {
            // Move towards the player using NavMesh
            navMeshAgent.SetDestination(player.position);
        }
    }

    // Function to find the closest enemySpawner
    Transform FindClosestTaggedObject(string tagName)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tagName);
        Transform closestSpawner = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject taggedObj in taggedObjects)
        {
            float distance = Vector3.Distance(transform.position, taggedObj.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestSpawner = taggedObj.transform;
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
        if (other.gameObject.tag == "PlayerAttack")
        {
            bool isPlayerAttacking;
            CarController3D basicCarController = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<CarController3D>();
            if (basicCarController == null)
            {
                isPlayerAttacking = false;
            }
            else
            {
                isPlayerAttacking = (basicCarController.isDrifting || basicCarController.isBoosting || basicCarController.CurrentSpeed > 20f);
            }
            if (isPlayerAttacking)
            {
                Destroy(this.gameObject);
            }
        }
        if (other.gameObject.tag == "Player")
        {
            var playerHealth = other.GetComponent<HealthComponent>();
            if (playerHealth == null)
            {
                return;
            }
            playerHealth.Damage(Damage);
            Destroy(this.gameObject);
        }

    }
    void SortTransformsByDistance(List<Transform> transforms, Transform reference)
    {
        transforms.Sort((a, b) =>
        {
            float distanceA = Vector3.Distance(a.position, reference.position);
            float distanceB = Vector3.Distance(b.position, reference.position);
            return distanceA.CompareTo(distanceB);
        });
    }

    public enum Tags
    {
        None,
        EnemySpawner,
        Ore,
        Gas,
        Crystal
    }
}