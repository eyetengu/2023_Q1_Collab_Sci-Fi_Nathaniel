using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game_Manager : MonoBehaviour
{
    private static Game_Manager _instance;
    public static Game_Manager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Game_Manager is NULL");
            return _instance;
        }
    }


//---------------FIELDS---------------
    [SerializeField] int _speedIndex;

    private bool _isCursorLocked;

    [Header("Game Conditions")]
    [SerializeField] private bool _isPaused;
    [SerializeField] private bool _gameOver;

    [Header("Time Scale")]
    [SerializeField] float timer;
    [SerializeField] float _timeScale;
    float[] _speedValues = { 0.0f, 0.5f, 1.0f, 2.0f };
    [SerializeField] private int _nextSceneToLoad;
    [SerializeField] private int _restartIndex;

//BUILT-IN FUNCTIONS
    private void Awake()
    {
        _instance = this;
    }
    
    void Start()
    {
        HideAndLock();
        _timeScale = 1.0f;
        GameSpeed();
    }

    void Update()
    {
        UserInput();        
        GameTimer();

        //Debug.Log("Time Scale: " + _timeScale);
    }


//PAUSE FUNCTIONS
    public void PausePlayer()
    {
        Event_Manager.Instance.Decree_PauseGame();
    }

    public void UnpausePlayer()
    {
        Event_Manager.Instance.Decree_PauseGame();
    }


//USER INPUTS
    void UserInput()
    { 
        //Restart Game
        if(_gameOver && Input.GetKeyDown(KeyCode.R))
        {
            _gameOver = false;
            _timeScale = 1.0f;
            GameSpeed();
            SceneManager.LoadScene(_restartIndex);
        }

    //Unpause And Keep Game Over
        if(_gameOver && Input.GetKeyDown(KeyCode.T))
        {
            Event_Manager.Instance.Decree_PauseState();

            _timeScale = 1.0f;            
            GameSpeed();
        }

    //SPEED INDEX MANIPULATOR
        //if (Input.GetKeyDown(KeyCode.P))
            //Event_Manager.Instance.Decree_PauseGame();

    //APPLICATION QUIT
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();                
    }

    void GameTimer()
    {
        timer += Time.deltaTime;
    }


//GAME CONDITIONS
    public void YouWin()
    {
        StartCoroutine(PauseBeforeNextLevel());
        Event_Manager.Instance.Decree_PauseGame();
        Event_Manager.Instance.Decree_GameWon();

        _gameOver = true;

        //_timeScale = 0;
        Debug.Log("YOU WIN!\nPress 'T' To Continue Exploring\n Press 'R' To Restart");
        //GameSpeed();

    }

    public void YouLose()
    {
        Event_Manager.Instance.Decree_PauseGame();
        Event_Manager.Instance.Decree_GameLost();

        _gameOver = true;

        _timeScale = 0;
        GameSpeed();
        Debug.Log("YOU LOSE!");
    }
    

//GAME FUNCTIONS
    void GameSpeed()
    {
        //Debug.Log("GameSpeed Adjusting");
        Time.timeScale = _timeScale;
    }


//CURSOR FUNCTIONS
//---INVISIBLE-----------------------------
    public void HideAndFree() 
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    public void HideAndConfine() 
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void HideAndLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


//---VISIBLE-------------------------------
    public void ShowAndFree()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ShowAndConfine()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void ShowAndLock() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }


//COROUTINES
    IEnumerator PauseBeforeNextLevel()
    {
        yield return new WaitForSeconds(2);
        _timeScale = 1.0f;
        GameSpeed();
        SceneManager.LoadScene(_nextSceneToLoad);
    }

}
