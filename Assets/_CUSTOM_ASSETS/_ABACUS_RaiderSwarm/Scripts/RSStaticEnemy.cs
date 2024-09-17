using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RSStaticEnemy : MonoBehaviour, IRSEnemy
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public float spawnInterval = 5f; // Time interval between spawns

    private float timer;
    private HealthComponent _healthComponent;

    private void Start()
    {
        _healthComponent = GetComponent<HealthComponent>();
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }

    public void TakeDamage(int damage)
    {
        _healthComponent.Damage(damage);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == RSPlayer.Instance?.gameObject)
        {
            Destroy(other.gameObject);
            if (RSGameManager.Instance != null)
            {
                RSGameManager.Instance.GameOver();
            }
            
        }

        BasicLazerScript basicLazerScript = other.gameObject.GetComponent<BasicLazerScript>();
        if (basicLazerScript != null)
        {
            Destroy(other.gameObject);

            TakeDamage(basicLazerScript.Damage);
        }
    }

    private void OnDestroy()
    {
        if(RSGameManager.Instance != null)
        {
            var itemDropComponent = GetComponent<RSPowerupDropper>();
            if (itemDropComponent != null)
            {
                itemDropComponent.DropPowerUp();
            }
            RSGameManager.Instance.AddScore(1000);
            RSGameManager.Instance.ObjectiveCompleted();
        }
    }
}
