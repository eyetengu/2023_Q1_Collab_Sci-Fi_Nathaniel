using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletGameObj;

    [SerializeField]
    private GameObject _bombGameObject;

    public static RSPlayer Instance {  get; private set; }
    public bool isRightFacing { get=> _isRightFacing; }

    private const float SPEED = 20f;
    private const float VERTICAL_SPEED = 75f;
    private const float LEFT_ROTATION = 270f;
    private const float RIGHT_ROTATION = 90f;
    private const float FORWARD_FORCE = 3f;
    private bool _isRightFacing;
    private RSPlayerInputActions _actions;
    private bool _isRotating;
    private float _fireRate = 0.25f;
    private float _canFire = -1;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Too many player instances!");
        }
        Instance = this;
        _actions = new RSPlayerInputActions();
        _actions.RSPlayer.Enable();

    }

    private void OnEnable()
    {
        _actions.RSPlayer.Left.performed += Left_performed;
        _actions.RSPlayer.Right.performed += Right_performed;
        _actions.RSPlayer.PrimaryFire.performed += PrimaryFire_performed;
        _actions.RSPlayer.SecondaryFire.performed += SecondaryFire_performed;

    }

    private void SecondaryFire_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            FireProjectile(_bombGameObject);
        }
    }

    private void PrimaryFire_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        FireProjectile(_bulletGameObj);
    }

    private void FireProjectile(GameObject projectile)
    {
        if (!_isRotating)
        {
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }

    private void OnDisable()
    {
        _actions.RSPlayer.Disable();
        _actions.RSPlayer.Left.performed -= Left_performed;
        _actions.RSPlayer.Right.performed -= Right_performed;

    }
    private void Start()
    {
        StartCoroutine(RotatePlayer(RIGHT_ROTATION));
        _isRightFacing = true;
    }
    private void Right_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!_isRightFacing && !_isRotating)
        {
            StartCoroutine(RotatePlayer(RIGHT_ROTATION));
            _isRightFacing = true;
        }
    }

    private void Left_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_isRightFacing && !_isRotating)
        {
            StartCoroutine(RotatePlayer(LEFT_ROTATION));
            _isRightFacing = false;
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    private void Update()
    {
        var moveDirection = _actions.RSPlayer.Move.ReadValue<Vector2>();
        var normalizedMoveDirection = moveDirection.normalized;
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
}
