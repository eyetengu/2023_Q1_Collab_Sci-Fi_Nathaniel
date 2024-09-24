using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RaiderSwarm.Enemy
{

    public class RSEnemyMovementUp : MonoBehaviour
    {
        public float speed = 5f; // Speed of the enemy
        public float frequency = 1f; // Frequency of the sine wave
        public float amplitude = 1f; // Amplitude of the sine wave

        private float startTime;

        void Start()
        {
            startTime = Time.time;
        }

        void Update()
        {
            float elapsedTime = Time.time - startTime;
            float x = Mathf.Sin(elapsedTime * frequency) * amplitude;
            float y = elapsedTime * speed;

            transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
            if (transform.position.y > 300f)
            {
                Destroy(gameObject);
            }
        }
    }
}
