using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Manager : MonoBehaviour
{
    private static Event_Manager _instance;
    public static Event_Manager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Event_Manager is NULL");
            return _instance;
        }
    }

    //--------------------------------------------------------

//GAME CONDITION
    public delegate void GameReady();
    public static event GameReady gameReady;

    public delegate void GameOver();
    public static event GameOver gameOver;
  

//GAME STATES
    public delegate void WinCondition();
    public static event WinCondition win;
    
    public delegate void GameLost();
    public static event GameLost lose;


//PAUSED STATES
    public delegate void PausePlayerMovement();
    public static event PausePlayerMovement pausePlayerMover;

    public delegate void UnpausePlayerMovement();
    public static event UnpausePlayerMovement _unpausePlayerMover;

    public delegate void GamePause();
    public static event GamePause pauseGame;

    public delegate void GameUnPaused();
    public static event GameUnPaused unPauseGame;


//PLAYER MOVEMENT
    public delegate void WalkAround();
    public static event WalkAround walkAround;



    //SCORE
    public delegate void IncreaseScore();
    public static event IncreaseScore increaseScore;
    bool _paused;


    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            Decree_GameWon();
        }
    }

    public void Score_Increase()
    {
        increaseScore();
    }

    //RULING BY DECREE
    public void Decree_GameReady()
    {
        if (gameReady != null)
            gameReady();
    }

    public void Decree_GameOver()
    {
        if (gameOver != null) ;
            gameOver();
    }

    public void Decree_GameWon()
    {
        if(win != null)
            win();
    }

    public  void Decree_GameLost()
    {
        if(lose != null)
            lose();
    }


//PAUSE STATES
    public void Decree_PauseState()
    {
        _paused = !_paused;
        if (_paused)
        {
            if (pauseGame != null)
                pauseGame();
        }
        else if (_paused == false)
        {
            if (unPauseGame != null)
                unPauseGame();
        }
    }

    public void Decree_PausePlayerMovement()
    {
        if(pausePlayerMover != null)
            pausePlayerMover();
    }

    public void Decree_UnPausePlayerMovement()
    {
        if(_unpausePlayerMover != null) _unpausePlayerMover();
    }

    public void Decree_PauseGame()
    {
        if(pauseGame != null)
            pauseGame();
    }

    public void Decree_UnpauseGame()
    {
        if(unPauseGame != null)
            unPauseGame();
    }


    public void Decree_WalkAround()
    {
        if (walkAround != null)
            walkAround();
    }
    //create a series of methods down here
    //call these methods from externally 
    //trigger the associated event
    //a single place for events may prove to be an effective means for locating(centrally) all events

}
