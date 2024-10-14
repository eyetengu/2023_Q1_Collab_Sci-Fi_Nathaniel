using RaiderSwarm.Interfaces;
using RaiderSwarm.Manager;
using RaiderSwarm.Player;
using RaiderSwarm.Powerup;
using System;
using System.Collections;
using UnityEngine;
namespace RaiderSwarm.Enemy
{
    public class RSStaticEnemy : MonoBehaviour, IRSEnemy
    {
        public GameObject enemyPrefab; // The enemy prefab to spawn
        public float spawnInterval = 5f; // Time interval between spawns

        private float timer;
        private HealthComponent _healthComponent;
        private Animator _animator;
        private bool _isDestroyed = false;
        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _animator = GetComponentInChildren<Animator>();
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

        private void OnEnable()
        {
            _healthComponent.OnDeath += _healthComponent_OnDeath;
            
        }

        private void OnDisable()
        {
            _healthComponent.OnDeath -= _healthComponent_OnDeath;
        }

        private void _healthComponent_OnDeath()
        {
            if (RSGameManager.Instance != null && !_isDestroyed)
            {
                _isDestroyed = true;
                var itemDropComponent = GetComponent<RSPowerupDropper>();
                if (itemDropComponent != null)
                {
                    itemDropComponent.DropPowerUp();
                }
                RSGameManager.Instance.AddScore(1000);
                RSGameManager.Instance.ObjectiveCompleted();
                StartCoroutine(DisableEnemy());
            }
        }

        private IEnumerator DisableEnemy()
        {
            _animator.SetTrigger("triggerDeath");
            yield return new WaitForSeconds(1.5f);
            gameObject.SetActive(false);
            yield return null;
        }

        void SpawnEnemy()
        {
            if (enemyPrefab != null && !_isDestroyed)
            {
                Instantiate(enemyPrefab, transform.position, transform.rotation);
            }
        }

        public void TakeDamage(int damage)
        {
            _animator.SetTrigger("triggerHit");
            _healthComponent.Damage(damage);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == RSPlayer.Instance?.gameObject && !_isDestroyed)
            {
                RSPlayer.Instance.DestroyPlayer();
            }

            IDamage iDamage = other.gameObject.GetComponent<IDamage>();
            if (iDamage != null)
            {
                Destroy(other.gameObject);

                TakeDamage(iDamage.Damage);
            }
        }
    }
}
