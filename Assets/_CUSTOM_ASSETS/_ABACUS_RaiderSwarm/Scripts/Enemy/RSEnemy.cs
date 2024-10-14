using RaiderSwarm.Interfaces;
using RaiderSwarm.Manager;
using RaiderSwarm.Player;
using RaiderSwarm.Powerup;
using System.Collections;
using UnityEngine;

namespace RaiderSwarm.Enemy
{
    public class RSEnemy : MonoBehaviour, IRSEnemy
    {
        private HealthComponent _healthComponent;

        public void TakeDamage(int damage)
        {
            _healthComponent.Damage(damage);
        }

        // Start is called before the first frame update
        void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
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
            var itemDropComponent = GetComponent<RSPowerupDropper>();
            if (itemDropComponent != null)
            {
                itemDropComponent.DropPowerUp();
            }
            if (RSGameManager.Instance != null)
            {
                RSGameManager.Instance.AddScore(100);
            }
            gameObject.SetActive(false);

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == RSPlayer.Instance?.gameObject)
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
