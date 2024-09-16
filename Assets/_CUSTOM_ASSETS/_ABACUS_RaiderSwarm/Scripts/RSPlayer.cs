using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSPlayer : MonoBehaviour
{
    public static RSPlayer Instance {  get; private set; }


    private const float SPEED = 10f;
    private const float VERTICAL_SPEED = 75f;
    private const float LEFT_ROTATION = 270f;
    private const float RIGHT_ROTATION = 90f;
    private const float FORWARD_FORCE = 1f;
    private bool _isRightFacing;
    private RSPlayerInputActions _actions;
    private bool _isRotating;

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
        if (!_isRightFacing)
        {
            StartCoroutine(RotatePlayer(RIGHT_ROTATION));
            _isRightFacing = true;
        }
    }

    private void Left_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_isRightFacing)
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
        if (!_isRotating)
        {
            var moveDirection = _actions.RSPlayer.Move.ReadValue<Vector2>();
            var normalizedMoveDirection = moveDirection.normalized;
            float verticalVector = normalizedMoveDirection.y * VERTICAL_SPEED * Time.deltaTime;
            float forwardVector = (FORWARD_FORCE + Mathf.Abs(normalizedMoveDirection.x)) * SPEED * Time.deltaTime;
            var targetVector = new Vector3(0, verticalVector, forwardVector);
            transform.Translate(targetVector);
        }
    }

    private IEnumerator RotatePlayer(float targetRotation)
    {
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
}
