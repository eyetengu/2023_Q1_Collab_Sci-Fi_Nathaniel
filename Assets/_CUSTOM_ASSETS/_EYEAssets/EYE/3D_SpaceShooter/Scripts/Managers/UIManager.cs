    using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Game_Manager _gameManager;
    private Camera_Manager_CDEND _cameraManager;
    Scene_Manager _sceneManager;

    [Header("UI DISPLAYS")]
    [Header("ENEMIES")]
    [SerializeField] private TMP_Text _enemiesTotal;
    [SerializeField] private TMP_Text _enemiesDead;
    [SerializeField] private TMP_Text _enemiesActive;

    [Header("PLAYER")]
    [SerializeField] private TMP_Text _playerMessage;
    [SerializeField] private Slider _playerHealthSlider;
    [SerializeField] private TMP_Text _scoreDisplay;
    [SerializeField] private TMP_Text _speedDisplay;

    [Header("UI PANELS")]
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _playerWinsPanel;
    [SerializeField] private GameObject _startupScreen;
    [SerializeField] private GameObject _creditsPanel;

    [Header("MESSAGES")]
    [SerializeField] GameObject[] _messages;

    [Header("PLAYER HUD")]
    [SerializeField] GameObject _playerHUD;
    [SerializeField] GameObject _persistentScreen;


//BUILT-IN FUNCTIONS
    private void OnEnable()
    {
        //Game_Manager.Instance.gameLost += GameOverSequence_UI;
        Event_Manager.gameOver += DisplayGameOverPanel;
        Event_Manager.win += DisplayPlayerWinPanel;
        Event_Manager.lose += DisplayPlayerLostPanel;
    }

    private void OnDisable()
    {
        //GameManager.gameLost -= GameOverSequence_UI();
        Event_Manager.gameOver -= DisplayGameOverPanel;
        Event_Manager.win -= DisplayPlayerWinPanel;
        Event_Manager.lose -= DisplayPlayerLostPanel;
    }

    private void Start()
    {
        _sceneManager = FindObjectOfType<Scene_Manager>();
        _gameManager = GameObject.FindObjectOfType<Game_Manager>();
        _cameraManager = GameObject.FindObjectOfType<Camera_Manager_CDEND>();
        _creditsPanel.SetActive(false);
        CloseAllMessages();
        HidePlayerHUD();
        _gameOverPanel.SetActive(false);
        _playerWinsPanel.SetActive(false);
        ShowStartupScreens();

    }


    //INITIAL FUNCTIONS
    void CloseAllMessages()
    {
        foreach (GameObject message in _messages)
            message.SetActive(false);
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

        StartCoroutine(IntroMessageTimer());
    }


    //GAME STATE
    public void DisplayGameStateMessage(string messageIn)
    {
        _playerMessage.text = messageIn;

        StartCoroutine(ClearPlayerMessageTimer());
    }

    public void DisplayGameOverPanel()
    {
        if (_gameOverPanel != null)
            _gameOverPanel.SetActive(true);
    }

    public void DisplayPlayerWinPanel()
    {
        _playerWinsPanel.SetActive(true);
        StartCoroutine(CreditPanelTimer());
    }

    public void DisplayPlayerLostPanel()
    {
        _gameOverPanel.SetActive(true);
    }

    IEnumerator CreditPanelTimer()
    {
        yield return new WaitForSeconds(2.0f);
        _playerWinsPanel.SetActive(false);
        _creditsPanel.SetActive(true);
    }


    //PLAYER MESSAGE
    public void ClearPlayerMessage()
    {
        _playerMessage.text = "";
    }
    public void UpdatePlayerMessage(string playerMessageIn)
    {
        _playerMessage.text = playerMessageIn;

        StartCoroutine(ClearPlayerMessageTimer());
    }
    IEnumerator ClearPlayerMessageTimer()
    {
        yield return new WaitForSeconds(4.0f);
        ClearPlayerMessage();
    }


//______HUD FUNCTIONS______
    //ENEMIES
    public void DisplayEnemyCounts(int total, int active, int dead)
    {
        //Debug.Log("Displaying Enemy Counts");
        _enemiesTotal.text = $"TOTAL    " + total;
        _enemiesActive.text = $"ACTIVE   " + active;
        _enemiesDead.text = $"DEAD     " + dead;
    }

    //HEALTH
    public void SliderSetMaxValue(int healthIn)
    {
        _playerHealthSlider.maxValue = healthIn;
    }
    public void UpdatePlayerHealthBar(int healthValue)
    {
        _playerHealthSlider.value = healthValue;
    }

    //PLAYER HUD
    void DisplayPlayerHUD()
    {
        //Enable the player HUD panels as well as the persistent panel
        //Triggers the gameReady event
        //Uses a coroutine to wait for 1.0 seconds before triggering spawnWave event

        _playerHUD.SetActive(true);
        _persistentScreen.SetActive(true);

        //Event_Manager.Instance.Decree_GameReady();
        Event_Manager.Instance.GameStartEventSequence();
        StartCoroutine(SpawnDelay());
    }

    void HidePlayerHUD()
    {
        _playerHUD.SetActive(false);
        _persistentScreen.SetActive(false);
    }

    //SCORE
    public void DisplayScore(int scoreIn)
    {
        _scoreDisplay.text = $"Score: {scoreIn.ToString()}";
    }

    //SPEED
    public void DisplaySpeed(float speedValueIn)
    {
        if (_speedDisplay != null)
            _speedDisplay.text = $"SPEED\n{(speedValueIn * 10).ToString("F2")}";
    }



//COROUTINES------------------------
//INTRO MESSAGES
    IEnumerator IntroMessageTimer()
    {
        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i <= _messages.Length - 1; i++)
        {
            _messages[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(2.0f);

            if (i == 2) { _cameraManager.EnableGroupIntroCamera(); }
        }

        yield return new WaitForSeconds(1.5f);

        _cameraManager.EnableGameCamera();

        yield return new WaitForSeconds(1.5f);

        foreach (var message in _messages)
            CloseAllMessages();

        //GAME READY EVENT TRIGGERED
        DisplayPlayerHUD();
        //Event_Manager.Instance.Decree_UnpauseGame();
    }

//SPAWN DELAY
    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(1.0f);
        Event_Manager.Instance.SpawnWave();
    }
}
