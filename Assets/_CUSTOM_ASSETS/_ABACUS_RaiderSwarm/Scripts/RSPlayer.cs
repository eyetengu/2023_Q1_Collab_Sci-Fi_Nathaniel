using RaiderSwarm.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RaiderSwarm.Player
{
    public class RSPlayer : MonoBehaviour
    {
        [SerializeField]
        private GameObject _bulletGameObj;
        [SerializeField]
        private GameObject _bigBulletGameObj;

        [SerializeField]
        private GameObject _bombGameObject;
        [SerializeField]
        private GameObject _missileGameObject;

        public static RSPlayer Instance { get; private set; }
        public bool isRightFacing { get => _isRightFacing; }
        public bool hasPrimaryPowerup { get; set; }
        public bool hasAlternatePowerup { get; set; }

        private const float SPEED = 20f;
        private const float VERTICAL_SPEED = 75f;
        private const float LEFT_ROTATION = 270f;
        private const float RIGHT_ROTATION = 90f;
        private const float FORWARD_FORCE = 3f;
        private bool _isRightFacing;
        private bool _isRotating;
        private float _fireRate = 0.75f;
        private float _canFire = -1;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Too many player instances!");
            }
            Instance = this;
        }
        private void OnEnable()
        {
            if (RSGameInput.Instance != null)
            {
                RSGameInput.Instance.OnLeftPressed += Instance_OnLeftPressed;
                RSGameInput.Instance.OnRightPressed += Instance_OnRightPressed;
                RSGameInput.Instance.OnFirePressed += Instance_OnFirePressed;
                RSGameInput.Instance.OnSecondaryPressed += Instance_OnSecondaryPressed;
            }
        }

        private void OnDisable()
        {
            if (RSGameInput.Instance != null)
            {
                RSGameInput.Instance.OnLeftPressed -= Instance_OnLeftPressed;
                RSGameInput.Instance.OnRightPressed -= Instance_OnRightPressed;
                RSGameInput.Instance.OnFirePressed -= Instance_OnFirePressed;
                RSGameInput.Instance.OnSecondaryPressed -= Instance_OnSecondaryPressed;
            }
        }

        private void Instance_OnSecondaryPressed()
        {
            if (Time.time > _canFire)
            {
                _canFire = Time.time + _fireRate;
                if (hasAlternatePowerup)
                {
                    FireProjectile(_missileGameObject);
                }
                else
                {
                    FireProjectile(_bombGameObject);
                }
            }
        }

        private void Instance_OnFirePressed()
        {
            if (hasPrimaryPowerup)
            {
                StartCoroutine(FireProjectiles(_bigBulletGameObj));
            }
            else
            {
                FireProjectile(_bulletGameObj);
            }
        }

        private void Instance_OnRightPressed()
        {
            if (!_isRightFacing && !_isRotating)
            {
                StartCoroutine(RotatePlayer(RIGHT_ROTATION));
                _isRightFacing = true;
            }
        }

        private void Instance_OnLeftPressed()
        {
            if (_isRightFacing && !_isRotating)
            {
                StartCoroutine(RotatePlayer(LEFT_ROTATION));
                _isRightFacing = false;
            }
        }

        private void FireProjectile(GameObject projectile)
        {
            if (!_isRotating)
            {
                Instantiate(projectile, transform.position, transform.rotation);
            }
        }

        private void Start()
        {
            StartCoroutine(RotatePlayer(RIGHT_ROTATION));
            _isRightFacing = true;
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        private void Update()
        {
            if (RSGameInput.Instance != null)
            {
                Vector2 normalizedMoveDirection = RSGameInput.Instance.GetMovementNormalized();
                float verticalVector = normalizedMoveDirection.y * VERTICAL_SPEED * Time.deltaTime;

                if (!_isRotating)
                {
                    float forwardVector = (FORWARD_FORCE + Mathf.Abs(normalizedMoveDirection.x)) * SPEED * Time.deltaTime;
                    var targetVector = new Vector3(0, verticalVector, forwardVector);
                    transform.Translate(targetVector);
                }
                else
                {
                    var targetVector = new Vector3(transform.position.x, transform.position.y, 0);
                    transform.position = targetVector;

                }

            }
        }


        private IEnumerator RotatePlayer(float targetRotation)
        {
            if (_isRotating == true)
            {
                yield return null;
            }
            _isRotating = true;
            float currentRotation = transform.eulerAngles.y;
            float startRotation = currentRotation;
            float endRotation = targetRotation;
            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime;
                float yRotation = Mathf.Lerp(startRotation, endRotation, t);
                transform.eulerAngles = new Vector3(0, yRotation, 0);
                yield return null;
            }

            _isRotating = false;
        }

        public static void Destroy()
        {
            Destroy(Instance);
        }

        IEnumerator FireProjectiles(GameObject bullet)
        {
            for (int i = 0; i < 3; i++)
            {
                // Instantiate the projectile at the fire point
                FireProjectile(bullet);

                // Wait for the specified delay before firing the next projectile
                yield return new WaitForSeconds(_fireRate);
            }
        }
    }
}
