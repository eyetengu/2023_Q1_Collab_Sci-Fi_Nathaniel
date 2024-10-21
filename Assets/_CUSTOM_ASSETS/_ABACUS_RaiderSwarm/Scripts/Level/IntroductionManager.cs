using RaiderSwarm.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace RaiderSwarm.Level
{
    public class IntroductionManager : MonoBehaviour
    {
        public GameObject introductionPanel;
        public Button startButton;
        private RSPlayerInputActions inputActions;

        void Start()
        {
            startButton.onClick.AddListener(StartGame);
        }

        void StartGame()
        {
            introductionPanel.SetActive(false);
            RSGameManager.Instance.GameStarted = true;
        }

        void Awake()
        {
            inputActions = new RSPlayerInputActions();
        }

        void OnEnable()
        {
            inputActions.RSUI.Enable();
            inputActions.RSUI.Accept.performed += OnStartGame;
        }

        void OnDisable()
        {
            inputActions.RSUI.Disable();
            inputActions.RSUI.Accept.performed -= OnStartGame;
        }

        void OnStartGame(InputAction.CallbackContext context)
        {
            startButton.onClick.Invoke();
        }
    }
}
