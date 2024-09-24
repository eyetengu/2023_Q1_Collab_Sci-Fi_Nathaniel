using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RaiderSwarm.Powerup
{

    public class RSPowerupDropper : MonoBehaviour
    {
        [System.Serializable]
        public class PowerUp
        {
            public GameObject prefab;
            public float dropChance; // The chance of this power-up dropping
        }

        public PowerUp[] powerUps;

        public void DropPowerUp()
        {
            float totalWeight = 0f;
            foreach (PowerUp powerUp in powerUps)
            {
                totalWeight += powerUp.dropChance;
            }

            float randomValue = Random.Range(0f, totalWeight);
            float cumulativeWeight = 0f;

            foreach (PowerUp powerUp in powerUps)
            {
                cumulativeWeight += powerUp.dropChance;
                if (randomValue < cumulativeWeight && powerUp.prefab != null)
                {
                    Instantiate(powerUp.prefab, transform.position, Quaternion.identity);
                    break;
                }
            }
        }

        // This method should be called when the enemy is defeated
        public void OnEnemyDefeated()
        {
            DropPowerUp();
        }
    }
}
