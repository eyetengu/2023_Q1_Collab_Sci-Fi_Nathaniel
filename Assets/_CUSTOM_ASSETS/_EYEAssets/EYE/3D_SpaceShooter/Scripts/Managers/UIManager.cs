using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;

    [Header("Text Fields")]
    [SerializeField] private TMP_Text _scoreDisplay;
    [SerializeField] private TMP_Text _playerMessage;
    [SerializeField] private TMP_Text _remainingEnemyDisplay;
    [SerializeField] private TMP_Text _speedDisplay;

    [Header("SLIDERS")]
    [SerializeField] private Slider _playerHealthSlider;

    [Header("GAME OBJECTS")]
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _startupScreen;


    private void OnEnable()
    {
        //_gameManager = GameObject.FindObjectOfType<GameManager>();
        //GameManager.gameOver += GameOverSequence_UI;
    }

    public void DisplaySpeed(float speedValueIn)
    {
        if(_speedDisplay != null)
            _speedDisplay.text = $"SPEED\n{(speedValueIn * 10).ToString("F2")}";
    }

    private void Start()
    {
        _gameOverPanel.SetActive(false);
        ShowStartupScreens();
    }

    void ShowStartupScreens()
    {
        if (_startupScreen != null)
        {
            _startupScreen.SetActive(true);
            StartCoroutine(SplashScreenTimer());
        }
    }

    IEnumerator SplashScreenTimer()
    {
        yield return new WaitForSeconds(3.0f);
        _startupScreen.SetActive(false);
    }

    //Score
    public void DisplayScore(int scoreIn)
    {
        _scoreDisplay.text = $"Score: {scoreIn.ToString()}";
    }
    
    //Health
    public void SliderSetMaxValue(int healthIn)
    {
        _playerHealthSlider.maxValue = healthIn;
    }
    public void UpdatePlayerHealthBar(int healthValue)
    {
        _playerHealthSlider.value = healthValue;
    }
    
    //Game State
    public void DisplayGameStateMessage(string messageIn)
    {
        _playerMessage.text = messageIn;

        StartCoroutine(ClearPlayerMessageTimer());
    }
    public void DisplayGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }

    //Player Message
    public void ClearPlayerMessage()
    {
        _playerMessage.text = "";
    }
    public void UpdatePlayerMessage(string playerMessageIn)
    {
        _playerMessage.text = playerMessageIn; 

        StartCoroutine(ClearPlayerMessageTimer());
    }
    
    //Enemy Count
    public void DisplayRemainingEnemies(int enemyCountIn)
    {
        _remainingEnemyDisplay.text = $"ENEMIES\n{enemyCountIn.ToString()}";
    }

    void GameOverSequence_UI(int value)
    {
        switch(value)
        {
            case 0:
                DisplayGameStateMessage("Player WinGs");
                break;
            case 1:
                DisplayGameOverPanel();
                break;

        }
    }

    IEnumerator ClearPlayerMessageTimer()
    {
        yield return new WaitForSeconds(3.0f);
        ClearPlayerMessage();
    }
}
