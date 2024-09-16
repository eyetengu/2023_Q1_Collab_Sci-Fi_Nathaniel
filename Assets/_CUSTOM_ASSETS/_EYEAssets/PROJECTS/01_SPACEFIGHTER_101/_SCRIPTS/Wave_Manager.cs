using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wave_Manager : MonoBehaviour
{
    UIManager _uiManager;

    [Header("WAVE IDENTIFICATION")]
    [SerializeField] int _maxWaves;
    [SerializeField] int _waveID;
    [SerializeField] string[] _waveLabel;
    [SerializeField] float _waveDelay = 3.0f;

    [Header("GAME CONDITION")]
    [SerializeField] bool _gameComplete;

    [Header("LEVEL CONDITION")]
    [SerializeField] bool _readyForNextWave = true;

    [Header("UI DISPLAY")]
    [SerializeField] TMP_Text _playerMessage;

    Enemy_Spawner _enemySpawner;
    bool _gameOver;


    void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _enemySpawner = GetComponent<Enemy_Spawner>();

        PrepareNewGameState();

        _waveLabel = new string[] {     "Somewhere Over The Milky Way",
                                        "My Kingdom For A Torque Converter",
                                        "Light Speed, LULU",
                                        "The Gaping Maw Of Your Destiny Awaits",
                                        "Stardate: 2087.a.103v- At Long Last- Space Madness Has Set In",
                                        "Wait! What Episode Is This?",
                                        "There Is No Way That's Your Real Hair",
                                        "Got A Zub Infestation You Need Gone? Contact Zub-Busters TODAY!",
                                        "We Really Should've Turned Left At Alberquerque",
                                        "Into The Great Wide Open- Tom Petty", 
                                        "All Aboard! Next Stop- Uranus",
                                        "Destination- Parts Unknown",
                                        "Nebula, Quasars & Meteor Showers; Oh My!"};
    }

    void PrepareNewGameState()
    {
        _gameOver = false;
        _readyForNextWave = true;
    }

    void Update()
    {
        if(_gameOver)
            UserInput();

        else if (_gameOver == false)
        {
            if (_readyForNextWave)
                BeginCurrentWave();
        }
    }

    //A wave manager should be able to display the current wave and title
    //it should trigger the spawn manager to spawn its characters in a timed/measured manner
    //it should have a function to advance to the next wave and repeat the process.
    //It should have a means to determine if the last level has been cleared and display the game completed

    void BeginCurrentWave()
    {
        DisplayWaveTitle();
        _readyForNextWave = false;
        _enemySpawner.StartSpawning();
        //AdvanceToNextWave();
    }

    void DisplayWaveTitle()
    {
        var message = "Wave " + _waveID + "\n" + _waveLabel[_waveID];
        //_playerMessage.text = message;
        _uiManager.UpdatePlayerMessage(message);

        StartCoroutine(ClearPlayerMessage());        
    }

    IEnumerator ClearPlayerMessage()
    {
        yield return new WaitForSeconds(3.0f);
        //_playerMessage.text = "";
        _uiManager.UpdatePlayerMessage("");

    }

    //-----WAVE ADVANCEMENT-------------------------------
    public void AdvanceToNextWave()
    {
        Debug.Log("Wave: Advance To Next Wave");
        _waveID++;

        if (_waveID > _maxWaves - 1)
        {
            StartCoroutine(GameOverTimer());
        }
        else
            StartCoroutine(AdvanceToNextWaveTimer());
    }

    IEnumerator AdvanceToNextWaveTimer()
    {
        Debug.Log("Advance To Next Wave Timer");
        yield return new WaitForSeconds(_waveDelay);
        _readyForNextWave = true;
    }

    //-----GAME OVER CONDITIONS---------------------------
    IEnumerator GameOverTimer()
    {
        yield return new WaitForSeconds(_waveDelay);
        _gameOver = true;
        Debug.Log("Game Over");
        _playerMessage.text = "GAME OVER\n(R)ESTART";       
    }

    void UserInput()
    {        
        if (Input.GetKeyDown(KeyCode.R))
            RestartGame();
 
        //if (Input.GetKeyDown(KeyCode.Space))
        //AdvanceToNextWave();
        //if (Input.GetKeyDown(KeyCode.E))
        //DisplayWaveTitle();
    }

    void RestartGame()
    {
        _uiManager.UpdatePlayerMessage("");

        //_playerMessage.text = "";
        _waveID = 0;
        _gameOver = false;
        _readyForNextWave = true;
    }








    
}
