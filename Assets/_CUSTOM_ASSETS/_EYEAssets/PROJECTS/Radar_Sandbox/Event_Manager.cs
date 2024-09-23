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

  
//GAME STATES
    public delegate void GameOver();
    public static event GameOver gameOver;

    public delegate void WinCondition();
    public static event WinCondition win;
    
    public delegate void GameLost();
    public static event GameLost lose;


//PAUSED STATES
//A pause state may exist where the player is pinned in place while his/her adherents flock to them
//moreover, you may need to pause everything so that nobody ends up at a disadvantage.
    public delegate void GamePause();
    public static event GamePause pauseGame;

    public delegate void GameUnPaused();
    public static event GameUnPaused unPauseGame;


//SCORE
    public delegate void IncreaseScore();
    public static event IncreaseScore increaseScore;
    bool _paused;


//ENEMY SPAWNING
    public delegate void SpawnEnemyWave();
    public static event SpawnEnemyWave spawnEnemyWave;


//NEW WAVES
    public delegate void NewWave();
    public static event NewWave newWave;


//-------------------------------------------------------

    private void Awake()
    {
        _instance = this;
    }

    public void GameStartEventSequence()
    {
        Decree_GameReady();
        Decree_UnpauseGame();        
    }

    public void Score_Increase()
    {
        increaseScore();
    }

    //GAME STATES
    public void Decree_GameReady()      
    {
        if (gameReady != null)
        {
            gameReady();
            Debug.Log("Game Ready");
        }
    }


    public void Decree_GameOver()       
    {   
        if (gameOver != null)     
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
            {
                pauseGame();
                Debug.Log("Pause Switch- Pause");
            }
        }
        else if (_paused == false)
        {
            if (unPauseGame != null)
            {
                unPauseGame();
                Debug.Log("Pause Switch_Unpause");
            }
        }
    }

    public void Decree_PauseGame()      
    {
        if (pauseGame != null)
        {
            pauseGame();
            Debug.Log("PauSE");
        }
    }

    public void Decree_UnpauseGame()    
    {
        if (unPauseGame != null)
        {
            unPauseGame();
            Debug.Log("UNPUased");
        }
    }

    //WAVES
    public void AdvanceToNewWave()
    {
        if (newWave != null)
            newWave();
        Debug.Log("New Wave");
    }

    public void SpawnWave()
    {
        if (spawnEnemyWave != null)
        {
            spawnEnemyWave();
            Debug.Log("Wave Spawning");
        }
    }    
}
