using RaiderSwarm.Interfaces;
using UnityEngine;
namespace RaiderSwarm.Weapon
{

    public class RSMissile : MonoBehaviour, IDamage
    {
        [SerializeField] private int _damage = 10;
        public int Damage { get => _damage; }

        [SerializeField] private float amplitude = 0.25f; // Amplitude (a)
        [SerializeField] private float period = 0.25f; // Period (b)
        [SerializeField] private float speed = 0.25f; // Speed of the movement

        private float startTime;

        void Start()
        {
            startTime = Time.time;
        }

        void Update()
        {
            float time = Time.time - startTime;
            float x = time * speed;
            float y = amplitude * Mathf.Cos((2 * Mathf.PI * x) / period);

            // Calculate the new position using transform.forward
            Vector3 forwardMovement = transform.forward * x;
            Vector3 newPosition = transform.position + forwardMovement + new Vector3(0f, y, 0f);

            transform.position = newPosition;
        }
    }
}
