using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class NewSpawnManager : MonoBehaviour
{
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
    }


    //ENEMIES
    public void SpawnNextGroup(int ID)
    {
        if (_sendingTroops == false)
        {
            _sendingTroops = true;
            _maxTroops = SPAWNING_FSM(ID);
            StartCoroutine(SpawnEnemyRoutine());
        }
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
        for(int i = 0; i < _maxTroops; i++)
        {
            //increase the total Enemy count            
            Debug.Log("Adding Enemy");
            _enemyCountManager.AddEnemy();
            
            //choose a random spawn point from a selection
            var randomSpawnPoint = Random.Range(0, _enemySpawnPoints.Length);
            Vector3 posToSpawn = _enemySpawnPoints[randomSpawnPoint].position;

            //create, define & parent enemy to container
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer;
            yield return new WaitForSeconds(2.0f);        
        }
        _enemyCountManager.WaveReleased = true;
        Debug.Log("Wave Released: " + _enemyCountManager.WaveReleased);
    }
}


//An Enemy Spawn class would have the following characteristics
//take in wave id
//run against fsm that holds spawn details that are taken in  spawned appropriately
//check to see if support personnel  have been spawned
// if false- then switch to true- use coroutine to spawn enemy count for this level (levelEnemyCount)
// if true- 