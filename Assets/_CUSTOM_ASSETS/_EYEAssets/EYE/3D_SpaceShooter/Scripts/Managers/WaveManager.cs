using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Event_Manager;

public class WaveManager : MonoBehaviour
{
    UIManager _uiManager;
    NewSpawnManager _spawnManager;
    

    [SerializeField] int _maxWavesToWin = 3;
    [SerializeField] int _waveID;


    bool _isGameOver;
    bool _gamePaused = true;
    //bool _gameReady;


    
    
    private AudioManager_3DSpace _audioManager;
    private GameManager _gameManager;


    bool _readyForNextWave;
    bool _enemySpawning;
    bool _gameReady;
    bool _showRandomLevel;

    string _message;
    //bool _wavesCreated;

    [SerializeField]
    string[] _waveLabel = new string[] { "For space is dark and full of stars",
                                        "HODOR!", "Geronimo!", "To Infinity And Beyond"};


//BUILT-IN FUNCTIONS
    private void OnEnable()
    {
        Event_Manager.gameReady     += RunWaveDisplayAndSpawnRoutine;
        Event_Manager.pauseGame     += PauseGame;
        Event_Manager.unPauseGame   += UnpauseGame;
        Event_Manager.spawnEnemyWave += RunWaveDisplayAndSpawnRoutine;
    }

    private void OnDisable()
    {
        Event_Manager.gameReady     -= RunWaveDisplayAndSpawnRoutine;
        Event_Manager.pauseGame     -= PauseGame;
        Event_Manager.unPauseGame   -= UnpauseGame;
        Event_Manager.spawnEnemyWave -= RunWaveDisplayAndSpawnRoutine;
    }

    private void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _uiManager = GameObject.FindObjectOfType<UIManager>();        
        _spawnManager = GameObject.FindObjectOfType<NewSpawnManager>();
        _audioManager = GameObject.FindObjectOfType<AudioManager_3DSpace>();

        _readyForNextWave = true;
        RunWaveDisplayAndSpawnRoutine();
        _gamePaused = false;
        _isGameOver = false;
    }
     
    
    public void RunWaveDisplayAndSpawnRoutine()
    {

        //if game is NOT paused, IS READY and NOT OVER
        if (_gamePaused == false && _gameReady && _isGameOver == false)
        {
            Debug.Log("Running Wave Display And Spawn Routine");

        //Player Wins
            if (_waveID >= _maxWavesToWin)
                PlayerWins();

        //Display info and Release swarm
            else if (_waveID < _maxWavesToWin)
            {
                DisplayCurrentWaveInformation();
                TellSpawnManagerToReleaseLevelEnemies();

                Debug.Log($"Advancing To Wave: {_waveID} /{_maxWavesToWin} To Win!");
            }
            _gameReady = true;
            _waveID++;
        }        
    }

    void DisplayCurrentWaveInformation()
    {
        if (_waveID < _maxWavesToWin)
        {
            _message = $"Wave: {_waveID}\n{_waveLabel[_waveID]}";
            _uiManager.DisplayGameStateMessage(_message);
        }
    }

    void TellSpawnManagerToReleaseLevelEnemies()
    {
        Debug.Log("Wave To Spawn Communique");
        _spawnManager.SpawnNextGroup(_waveID);
    }


    //This timer might be in reference to the display of the wave information in the UI
    IEnumerator FirstWaveTimer()
    {
        Debug.Log("STARTING WAVE: " + _waveID);
        //_readyForNextWave = true;
        yield return new WaitForSeconds(2);
        //TellSpawnManagerToReleaseLevelEnemies();
        //DisplayCurrentWaveInformation();
    }

    
//---------------------------------------------------------------
//---------------GAME STATES-------------------------------------

//BOOL CONDITIONS
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
        Debug.Log("Player Loses Message");

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

    ///A wave manager should do three things: Display the current wave information, Tell the spawn Manager to spawn enemies & advance to the next wave
    ///It should be relatively simple and straightforward to create
    ///
   
}