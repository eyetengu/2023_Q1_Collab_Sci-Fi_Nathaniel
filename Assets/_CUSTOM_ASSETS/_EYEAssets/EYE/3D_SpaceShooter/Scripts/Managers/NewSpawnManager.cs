using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSpawnManager : MonoBehaviour
{
    UIManager _uiManager;
    WaveManager _waveManager;

    [Header("ENEMIES")]
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Transform _enemyContainer;
    [SerializeField] int _maxTroops;

    //[SerializeField] bool _countingEnemies;

    [Header("SPAWN POINTS")]
    [SerializeField] Transform[] _enemySpawnPoints;
    [SerializeField] bool _sendingTroops;

    int _enemyCount;
    int _totalEnemies;
    int _deadEnemies;
    int _activeEnemies;
    int _waveID;
    bool _advancingWave;

    bool _countingEnemies;
    

//BUILT-IN FUNCTIONS
    private void Start()
    {
        _uiManager = GameObject.FindObjectOfType<UIManager>();
        _waveManager = GameObject.FindObjectOfType<WaveManager>();

        _totalEnemies = 0;
        _deadEnemies = 0;
    }

    private void FixedUpdate()
    {
        //EnemyCounter();   

        if(_countingEnemies)
        {
            if (_activeEnemies == 0)
                _waveManager.AdvanceToNextWave();
        }
    }


//ENEMIES
    public void SpawnNextGroup(int ID)
    {
        _sendingTroops = false;
        SpawnLevelTroops(ID);
    }


//CORE FUNCTIONS
    void SpawnLevelTroops(int waveIndex)
    {
        if (_sendingTroops == false)
        {
            //Debug.Log("Spawning Enemy Group: " + waveIndex);

            _sendingTroops = true;

            switch (waveIndex)
            {
                case 0:
                    _maxTroops = 1;
                    break;
                case 1:
                    _maxTroops = 2;
                    break;
                case 2:
                    _maxTroops = 3;
                    break;
                case 3:
                    _maxTroops = 4;
                    break;
                case 4:
                    _maxTroops = 5;
                    break;
                case 5:
                    _maxTroops = 6;
                    break;

                default:
                    break;
            }

            //Debug.Log($"Sending Troops: {_maxTroops}");
            StartCoroutine(SpawnEnemyRoutine());
        }
    }


//COROUTINES
    IEnumerator SpawnEnemyRoutine()
    {
        for(int i = 0; i < _maxTroops; i++)
        {
            //increase the total Enemy count
            _totalEnemies++;
            _activeEnemies++;

            //choose a random spawn point from a selection
            var randomSpawnPoint = Random.Range(0, _enemySpawnPoints.Length);
            Vector3 posToSpawn = _enemySpawnPoints[randomSpawnPoint].position;

            //create, define & parent enemy to container
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer;
            yield return new WaitForSeconds(2.0f);        
        }
        _countingEnemies = true;
    }

//--------------------------------------------------------------------------------------------------

    public void EnemyDies()
    {
        _activeEnemies--;
        _deadEnemies++;
    }


    void EnemyCounter()
    {
        var numberOfEnemies = DetermineSizeOfEnemyForce();

        if (numberOfEnemies == 0 && _advancingWave == false)
        {
            _advancingWave = true;

            Debug.Log("Advancing To Next Wave");
            _waveManager.AdvanceToNextWave();
            //_countingEnemies = false;
        }

        _deadEnemies = _totalEnemies - _activeEnemies;
        //_uiManager.DisplayRemainingEnemies(numberOfEnemies);
        _uiManager.DisplayEnemyCounts(_totalEnemies, _deadEnemies, _activeEnemies);
    }

    int DetermineSizeOfEnemyForce()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length > 0)
        {
            int numberOfEnemies = enemies.Length;
            //_uiManager.DisplayRemainingEnemies(numberOfEnemies);
            _uiManager.DisplayEnemyCounts(_totalEnemies, _deadEnemies, _activeEnemies);

            return numberOfEnemies;
        }
        _uiManager.DisplayRemainingEnemies(0);
        return 0;
    }



//POTENTIAL USE FUNCTIONS
    void SpawnAtRandomX020()
    {
        //Vector3 posToSpawn = new Vector3(Random.Range(-20f, 20f), 0, 20);     //This is a random spawn point along the x axis at y(0) & z(20)
        //Vector3 posToSpawn = _enemySpawnLocation.position;
        //int posCap =  (int) _enemySpawnPoints.Count();
    }

}


//An Enemy Spawn class would have the following characteristics
//take in wave id
//run against fsm that holds spawn details that are taken in  spawned appropriately
//check to see if support personnel  have been spawned
// if false- then switch to true- use coroutine to spawn enemy count for this level (levelEnemyCount)
// if true- 