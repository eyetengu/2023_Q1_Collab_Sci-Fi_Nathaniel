using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    UIManager _uiManager;
    NewSpawnManager _spawnManager;
    [SerializeField] private AudioManager_3DSpace _audioManager;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private List<Wave> _waves = new List<Wave>();

    [SerializeField] int _waveID;
    bool _isGameOver;
    Wave _currentWave;


    private void OnEnable()
    {
        //GameManager.gameOver += GameOverSequence_WaveMgr;
    }

    private void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _uiManager = GameObject.FindObjectOfType<UIManager>();        
        _spawnManager = GameObject.FindObjectOfType<NewSpawnManager>();
        _audioManager = GameObject.FindObjectOfType<AudioManager_3DSpace>();

        CreateWaves();
        StartCoroutine(FirstWaveTimer());
    }
     
    private void Update()
    {
       

    }
    
    //CORE FUNCTIONS
    void CreateWaves()
    {
        for (int i = 0; i < 4; i++)
        {
            var newWave = new Wave(i.ToString(), i * 2);
            _waves.Add(newWave);
        }
    }
    
    public void AdvanceToNextWave()
    {
        if (_isGameOver == false)
        {
            _waveID++;
            
            if (_waveID > _waves.Count - 1)
            {
                PlayerWins();
            }

            if (_waveID <= _waves.Count - 1)
            {
                _currentWave = _waves[_waveID];
                DisplayWaveInfo();

                StartCoroutine(EnemyWaveDelay());
            }
        }
    }
    
    void DisplayWaveInfo()
    {
        if (_waveID <= _waves.Count - 1) 
            _currentWave = _waves[_waveID];

        var message = $"Wave: {_currentWave.waveName}\nEnemy Count: {_currentWave.maxEnemyCount}";
        _uiManager.DisplayGameStateMessage(message);    
    }

    IEnumerator EnemyWaveDelay()
    {
        yield return new WaitForSeconds(1);
        _spawnManager.SendInTheTroops(true, _currentWave.maxEnemyCount);
    }

    //GAME CONDITIONS
    void GameOverSequence_WaveMgr(int value)
    {        
        switch(value)
        {
            case 0:
                PlayerWins();
                break;
                case 1:
                PlayerLoses();
                break; 
        }
    }

    void PlayerWins() 
    {
        _isGameOver = true;
        _gameManager.Died = true;
    }

    public void PlayerLoses() 
    { 
        _isGameOver = true; 
        _uiManager.DisplayGameOverPanel();
        _audioManager.PlayGameOver();
    }

   IEnumerator FirstWaveTimer()
    {
        yield return new WaitForSeconds(2);
        AdvanceToNextWave();
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