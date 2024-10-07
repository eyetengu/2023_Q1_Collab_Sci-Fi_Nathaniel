using RaiderSwarm.Interfaces;
using RaiderSwarm.Manager;
using RaiderSwarm.Player;
using RaiderSwarm.Powerup;
using UnityEngine;
namespace RaiderSwarm.Enemy
{
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
            if (RSGameManager.Instance.GameStarted)
            {
                timer += Time.deltaTime;

                if (timer >= spawnInterval)
                {
                    SpawnEnemy();
                    timer = 0f;
                }
            }
        }

        void SpawnEnemy()
        {
            if (enemyPrefab != null)
            {
                Instantiate(enemyPrefab, transform.position, transform.rotation);
            }
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

            IDamage iDamage = other.gameObject.GetComponent<IDamage>();
            if (iDamage != null)
            {
                Destroy(other.gameObject);

                TakeDamage(iDamage.Damage);
            }
        }

        private void OnDestroy()
        {
            if (RSGameManager.Instance != null)
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
}
