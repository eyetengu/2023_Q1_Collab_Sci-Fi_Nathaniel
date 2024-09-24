using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class NewSpawnManager : MonoBehaviour
{
    /// <summary>
    /// The Spawn Manager is a straightforward component to code.
    /// Ours will operate when a 'spawnEnemy(int waveNumber)' function is called
    /// Once called the function will check the waveNumber against the 
    /// 'Spawning_FSM' function that returns the maximum number of enemies to spawn during this wave.
    /// Then we run the 'SpawnEnemyRoutine' Coroutine which instantiates an enemy every 2.0 seconds.
    /// Inside the coroutine we determine which of our spawn points to instantiate the new enemy from
    /// and instantiate the enemy at that point
    /// After all enemies have been placed on the board, we tell the enemy count manager that the 
    /// wave has been released
    /// 
    /// 
    /// /// </summary>
    
    UIManager _uiManager;
    WaveManager _waveManager;
    Enemy_Count_Manager _enemyCountManager;

    [Header("ENEMIES")]
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Transform _enemyContainer;
    [SerializeField] int _maxTroops;

    [Header("SPAWN POINTS")]
    [SerializeField] Transform[] _enemySpawnPoints;
    [SerializeField] bool _sendingTroops;

        
//BUILT-IN FUNCTIONS
    private void Start()
    {
        _uiManager = GameObject.FindObjectOfType<UIManager>();
        _waveManager = GameObject.FindObjectOfType<WaveManager>();
        _enemyCountManager = FindObjectOfType<Enemy_Count_Manager>();
        _sendingTroops = false;
    }


    //ENEMIES
    public void SpawnNextGroup(int ID)
    {
        _maxTroops = SPAWNING_FSM(ID);

        Debug.Log("Spawning New Group: " + _maxTroops);
        StartCoroutine(SpawnEnemyRoutine());        
    }


//CORE FUNCTIONS
    int SPAWNING_FSM(int waveIndex)
    { 
        int troops = 0;
        switch (waveIndex)
        {
            case 0:
                troops = 5;
                break;
            case 1:
                troops = 3;
                break;
            case 2:
                troops = 4;
                break;
            case 3:
                troops = 2;
                break;
            case 4:
                troops = 1;
                break;
            case 5:
                troops = 6;
                break;

            default:
                break;
        }
        
        return troops;
    }


//COROUTINES
    IEnumerator SpawnEnemyRoutine()
    {
        var countReleased = 0;

        for(int i = 0; i < _maxTroops; i++)
        {
            countReleased++;
            _enemyCountManager.AddEnemy();

            SelectRandomSpawnPoint();

            yield return new WaitForSeconds(2.0f);        
        }
        _enemyCountManager.WaveReleased = true;
        Debug.Log($"Wave of {countReleased} Finished Releasing: {_enemyCountManager.WaveReleased}");
    }

    void SelectRandomSpawnPoint()
    {
        var randomSpawnPoint = Random.Range(0, _enemySpawnPoints.Length);
        Vector3 posToSpawn = _enemySpawnPoints[randomSpawnPoint].position;

        GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
        newEnemy.transform.parent = _enemyContainer;
    }

}



//An Enemy Spawn class would have the following characteristics
//take in wave id
//run against fsm that holds spawn details that are taken in  spawned appropriately
//spawn enemies in every 2.0 seconds until all spawned in.
// 
//  