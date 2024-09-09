using System;
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
        var playerTag = GameObject.FindGameObjectWithTag(Tags.Player.ToString());
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
            if (closestGasDrill != null && closestGasDrill.GetComponent<ResourceController>().IsActiveDrill)
            {
                list.Add(closestGasDrill);
            }
            Transform closestOreDrill = FindClosestTaggedObject(Tags.Ore.ToString());
            if (closestOreDrill != null && closestOreDrill.GetComponent<ResourceController>().IsActiveDrill)
            {
                list.Add(closestOreDrill);
            }
            Transform closestCrystalDrill = FindClosestTaggedObject(Tags.Crystal.ToString());
            if (closestCrystalDrill != null && closestCrystalDrill.GetComponent<ResourceController>().IsActiveDrill)
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
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
        randomDirection += origin;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas);
        return hit.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        var isValidTag = Enum.TryParse(typeof(Tags), other.gameObject.tag, out object result);
        if (isValidTag)
        {
            switch (result)
            {
                case Tags.PlayerAttack:
                    CheckIfHit(other);
                    break;
                case Tags.None:
                case Tags.Player:
                case Tags.Ore:
                case Tags.Gas:
                case Tags.Crystal:
                default:
                    DoDamage(other);
                    break;
            }
        }
    }

    private void CheckIfHit(Collider other)
    {
        bool isPlayerAttacking;
        CarController3D basicCarController = GameObject.FindGameObjectWithTag(Tags.Player.ToString()).gameObject.GetComponent<CarController3D>();
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

    private void DoDamage(Collider other)
    {
        var targetHealth = other.GetComponent<HealthComponent>();
        if (targetHealth == null)
        {
            return;
        }
        targetHealth.Damage(Damage);
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
        Crystal,
        PlayerAttack,
        Player
    }
}