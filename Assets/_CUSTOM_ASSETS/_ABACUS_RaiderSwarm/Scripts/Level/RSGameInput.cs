using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RaiderSwarm.Manager
{

    public class RSGameInput : MonoBehaviour
    {
        public static RSGameInput Instance { get; private set; }
        private RSPlayerInputActions _actions;

        // Define a delegate (if using non-generic pattern).
        public delegate void Left_Pressed();
        public delegate void Right_Pressed();
        public delegate void Fire_Pressed();
        public delegate void Secondary_Pressed();
        public delegate void Restart_Pressed();

        // Define an event based on that delegate.
        public event Left_Pressed OnLeftPressed;
        public event Right_Pressed OnRightPressed;
        public event Fire_Pressed OnFirePressed;
        public event Secondary_Pressed OnSecondaryPressed;
        public event Restart_Pressed OnRestartPressed;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Too many input instances!");
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        private void OnEnable()
        {
            _actions = new RSPlayerInputActions();
            _actions.RSPlayer.Enable();
            _actions.RSPlayer.Left.performed += Left_performed;
            _actions.RSPlayer.Right.performed += Right_performed;
            _actions.RSPlayer.PrimaryFire.performed += PrimaryFire_performed;
            _actions.RSPlayer.SecondaryFire.performed += SecondaryFire_performed;
            _actions.RSPlayer.Restart.performed += Restart_performed;
        }


        private void OnDisable()
        {
            _actions.RSPlayer.Left.performed -= Left_performed;
            _actions.RSPlayer.Right.performed -= Right_performed;
            _actions.RSPlayer.PrimaryFire.performed -= PrimaryFire_performed;
            _actions.RSPlayer.SecondaryFire.performed -= SecondaryFire_performed;
            _actions.RSPlayer.Restart.performed -= Restart_performed;
            _actions.RSPlayer.Disable();
        }

        public Vector2 GetMovementNormalized()
        {
            var moveDirection = _actions.RSPlayer.Move.ReadValue<Vector2>();
            var normalizedMoveDirection = moveDirection.normalized;
            return normalizedMoveDirection;
        }
        private void Restart_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnRestartPressed?.Invoke();
        }

        private void Right_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnRightPressed?.Invoke();
        }

        private void Left_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnLeftPressed?.Invoke();
        }

        private void SecondaryFire_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnSecondaryPressed?.Invoke();
        }

        private void PrimaryFire_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnFirePressed?.Invoke();
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }
}