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
        private AudioSource audioSource;
        [SerializeField] private AudioClip[] audioClips;

        private Vector3 _startingPosition;
        private float _distanceFromSpawn = 300f;

        public void TakeDamage(int damage)
        {
            PlayAudioClip(0);

            _healthComponent.Damage(damage);
        }
        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();

        }
        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();

            _startingPosition = transform.position;
        }

        private void OnEnable()
        {
            _healthComponent.OnDeath += _healthComponent_OnDeath;
        }
        private void OnDisable()
        {
            _healthComponent.OnDeath -= _healthComponent_OnDeath;
        }

        private void Update()
        {
            var currentPosition = transform.position;
            var offset = currentPosition - _startingPosition;
            if (Mathf.Abs(offset.x) > _distanceFromSpawn || Mathf.Abs(offset.y) > _distanceFromSpawn)
            {
                gameObject.SetActive(false);
            }
        }
        private void _healthComponent_OnDeath()
        {
            PlayAudioClip(1);
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
                other.gameObject.SetActive(false);

                TakeDamage(iDamage.Damage);
            }
        }
        public void PlayAudioClip(int index)
        {
            if (index >= 0 && index < audioClips.Length)
            {
                audioSource.clip = audioClips[index];
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("Invalid audio clip index");
            }


        }
    }
}
