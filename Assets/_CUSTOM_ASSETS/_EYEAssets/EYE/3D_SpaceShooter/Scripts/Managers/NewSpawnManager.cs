using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewSpawnManager : MonoBehaviour
{
    UIManager _uiManager;
    WaveManager _waveManager;
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Transform _enemyContainer;

    [SerializeField] bool _sendingTroops;
    [SerializeField] int _maxTroops;

    [SerializeField] bool _countingEnemies;
    int _enemyCount;

    //[SerializeField] Transform _enemySpawnLocation;
    [SerializeField] Transform[] _enemySpawnPoints;

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        _uiManager = GameObject.FindObjectOfType<UIManager>();
        _waveManager = GameObject.FindObjectOfType<WaveManager>();
    }

    private void FixedUpdate()
    {
        if(_countingEnemies)                
            EnemyCounter();   
        else
            DetermineSizeOfEnemyForce();        
    }

    public void SendInTheTroops(bool value, int number)
    {
        if (_sendingTroops == false)
        {
            _sendingTroops = true;
            _maxTroops = number;

            StartCoroutine(SpawnEnemyRoutine());

            Debug.Log($"Sending Troops: {number}");
        }        
    }

    IEnumerator SpawnEnemyRoutine()
    {
        _countingEnemies = false;

        for(int i = 0; i < _maxTroops; i++)
        {
            //Vector3 posToSpawn = new Vector3(Random.Range(-20f, 20f), 0, 20);     //This is a random spawn point along the x axis at y(0) & z(20)
            //Vector3 posToSpawn = _enemySpawnLocation.position;
            //int posCap =  (int) _enemySpawnPoints.Count();
            var randomSpawnPoint = Random.Range(0, _enemySpawnPoints.Length);
            Vector3 posToSpawn = _enemySpawnPoints[randomSpawnPoint].position;

            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer;
            yield return new WaitForSeconds(2.0f);        
        }

        _sendingTroops = false;
        _countingEnemies= true;
    }

    void EnemyCounter()
    {
        var numberOfEnemies = DetermineSizeOfEnemyForce();

        if (numberOfEnemies == 0)
        {
            Debug.Log("Advancing To Next Wave");
            _waveManager.AdvanceToNextWave();
            _countingEnemies = false;
        }
        
        _uiManager.DisplayRemainingEnemies(numberOfEnemies);
    }

    int DetermineSizeOfEnemyForce()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length > 0)
        {
            int numberOfEnemies = enemies.Length;
            _uiManager.DisplayRemainingEnemies(numberOfEnemies);
            
            return numberOfEnemies;
        }
        _uiManager.DisplayRemainingEnemies(0);
        return 0;
    }
}
