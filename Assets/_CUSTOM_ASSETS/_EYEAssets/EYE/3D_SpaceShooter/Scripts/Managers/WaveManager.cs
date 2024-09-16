using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    UIManager _uiManager;
    NewSpawnManager _spawnManager;
    private AudioManager_3DSpace _audioManager;
    private GameManager _gameManager;

    //[SerializeField] private List<Wave> _waves = new List<Wave>();
    [SerializeField] int _maxWavesToWin = 3;

    [SerializeField] int _waveID;
    bool _isGameOver;
    Wave _currentWave;

    bool _gamePaused = true;
    bool _gameReady;
    bool _wavesCreated;
    bool _readyForNextWave;
    bool _enemySpawning;

    bool _showRandomLevel;

    [SerializeField]
    string[] _waveLabel = new string[] { "For space is dark and full of stars",
                                        "HODOR!", "Geronimo!", "To Infinity And Beyond"};


//BUILT-IN FUNCTIONS
    private void OnEnable()
    {
        Event_Manager.gameReady += SetGameReady;
        Event_Manager.pauseGame += PauseGame;
        Event_Manager.unPauseGame += UnpauseGame;
    }

    private void OnDisable()
    {
        Event_Manager.gameReady -= SetGameReady;
        Event_Manager.pauseGame -= PauseGame;
        Event_Manager.unPauseGame -= UnpauseGame;
    }

    private void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _uiManager = GameObject.FindObjectOfType<UIManager>();        
        _spawnManager = GetComponent<NewSpawnManager>();
        _audioManager = GameObject.FindObjectOfType<AudioManager_3DSpace>();

        _readyForNextWave = true;
    }
     
    private void Update()
    {
        if (_gamePaused == false && _gameReady && _isGameOver == false)
        {
            if (_enemySpawning == false)
            {
                _enemySpawning = true;

                if (_readyForNextWave)
                    StartCoroutine(FirstWaveTimer());

                //Debug.Log("Wave Manager Enabled");
            }
        }
    }

    IEnumerator FirstWaveTimer()
    {
        Debug.Log("STARTING WAVE: " + _waveID);
        _readyForNextWave = true;
        yield return new WaitForSeconds(2);
        _spawnManager.SpawnNextGroup(_waveID);
        DisplayWaveInfo();
    }

    public void AdvanceToNextWave()
    {
        if (_isGameOver == false)
        {
            _waveID++;
            
            Debug.Log($"Advancing To Next Wave: {_waveID} /{_maxWavesToWin} To Win!");

            if (_waveID > _maxWavesToWin)
                PlayerWins();

            else if (_waveID < _maxWavesToWin)
            {
                //_currentWave = _waves[_waveID];
                Debug.Log("WaveTimer In Effect");
                DisplayWaveInfo();

                //StartCoroutine(EnemyWaveDelay());
                StartCoroutine(FirstWaveTimer());
            }
        }
    }


//BOOL CONDITIONS
    void SetGameReady()
    {
        _gameReady = true;
    }

    void PauseGame()
    {
        _gamePaused = true;
    }
    
    void UnpauseGame()
    {
        _gamePaused = false;
    }
    

//GAME OVER CONDITIONS
    void PlayerWins() 
    {
        _isGameOver = true;
        //_gameManager.Died = true;
        Event_Manager.Instance.Decree_GameWon();
        Debug.Log("Player Wins Message");

    }

    public void PlayerLoses() 
    { 
        _isGameOver = true; 
        _uiManager.DisplayGameOverPanel();
        Event_Manager.Instance.Decree_GameLost();
    }


//CORE FUNCTIONS
    void DisplayWaveInfo()
    {
        //if (_waveID < _maxWavesToWin) 
            //_currentWave = _waves[_waveID];

        var message = $"Wave: {_waveID}\n{_waveLabel[_waveID]}";

        _uiManager.DisplayGameStateMessage(message);    
    }

    IEnumerator EnemyWaveDelay()
    {
        yield return new WaitForSeconds(1);
        _spawnManager.SpawnNextGroup(_waveID);
    }


//GAME CONDITIONS
    void GameOverSequence_WaveMgr(int value)
    {
        Event_Manager.Instance.Decree_GameOver();
        switch (value)
        {
            case 0:
                PlayerWins();
                break;
            case 1:
                PlayerLoses();
                break; 
        }
    }  
}


[System.Serializable]
public class Wave
{
    public string waveName;
    public int maxEnemyCount;


    public Wave(string name)
    {
        waveName = "Wave: " + name.ToLower();
    }

    public Wave(string name, int maxIn)
    {
        waveName= name;
        maxEnemyCount = maxIn;
    }
}