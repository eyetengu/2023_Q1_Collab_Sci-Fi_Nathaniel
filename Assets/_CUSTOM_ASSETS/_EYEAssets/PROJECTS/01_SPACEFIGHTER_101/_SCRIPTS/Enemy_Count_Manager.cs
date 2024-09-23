using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Count_Manager : MonoBehaviour
{
    UIManager _uiManager;
    WaveManager _waveManager;

    [SerializeField] int _totalEnemy;
    [SerializeField] int _activeEnemy;
    [SerializeField] int _deadEnemy;

    //bool _waveReleased;
    public bool WaveReleased { get; set; }


    //BUILT-IN FUNCTIONS
    void Start()
    {
        _waveManager = FindObjectOfType<WaveManager>();
        _uiManager = FindObjectOfType<UIManager>();

        DisplayEnemyBodyCount();
    }

    private void Update()
    {
        //Here is where we check to see if the enemies have been spawned and if their active count is zero
        //if the enemy wave has been released AND there are no more enemies(presumably, because they are all dead)
        //Trigger the Spawn Wave event
        //Run the Wave Manager
        if (WaveReleased && _activeEnemy <= 0)
        { 
            WaveReleased = false;
            Debug.Log("All Enemies Have Been Killed"); 
            Event_Manager.Instance.SpawnWave();            
        }
    }


//ENEMY COUNT UPDATES
    public void AddEnemy() 
    {
        Debug.Log("Add To Enemy Count Manager"); 
        _totalEnemy++; 
        _activeEnemy++;
        DisplayEnemyBodyCount();
    }

    public void RemoveEnemy()
    {
        if (_activeEnemy > 0)
        {
            _activeEnemy--;
            _deadEnemy++;
            Event_Manager.Instance.Score_Increase();
        }
        DisplayEnemyBodyCount();
    }


//ENEMY COUNT DISPLAY
    void DisplayEnemyBodyCount()
    { 
        _uiManager.DisplayEnemyCounts(_totalEnemy, _activeEnemy, _deadEnemy); 
    }

}
