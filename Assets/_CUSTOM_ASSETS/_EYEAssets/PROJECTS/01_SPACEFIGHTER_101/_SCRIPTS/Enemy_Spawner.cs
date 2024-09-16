using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [Header("POTENTIAL ENEMIES")]
    [SerializeField] GameObject[] _enemyPrefabs;
    [SerializeField] GameObject _enemyPrefabSelected;

    [Header("ENEMY COUNT")]
    [SerializeField] int _totalEnemies;
    [SerializeField] int _enemiesActive;

    [Header("LOCATION TRANSFORMS")]
    [SerializeField] Transform _enemyHangar;
    [SerializeField] Transform _enemyGraveyard;

    [Header("UI DISPLAYS")]
    [SerializeField] TMP_Text _totalMessage;
    [SerializeField] TMP_Text _deadMessage;
    [SerializeField] TMP_Text _activeMessage;

    [Header("DELAYS")]
    [SerializeField] float _spawnDelay;

    Wave_Manager _waveManager;
    bool _waveComplete;

    int _spawnLevels;
    int _enemyType01;
    int _enemyType02;
    int _enemyType03;
    int _enemyType04;
    int _deadEnemy;

    private void Start()
    {
        _waveManager = GetComponent<Wave_Manager>();
    }

    private void Update()
    {
        UpdateUIDisplay();
        CalculateRemainingEnemies();
    }

    void UpdateUIDisplay()
    {
        if (_totalMessage != null)
        {
            string totalMessage = "Total: " + _totalEnemies.ToString();
            _totalMessage.text = totalMessage;
        }
        if (_deadMessage != null)
        {
            string deadMessage = "Dead: " + _deadEnemy.ToString();
            _deadMessage.text = deadMessage;
        }
        if (_activeMessage != null)
        {
            string activeMessage = "Active: " + _enemiesActive.ToString();
            _activeMessage.text = activeMessage;
        }
    }

    void CalculateRemainingEnemies()
    {
        _enemiesActive = _totalEnemies - _deadEnemy;
    }

    public void StartSpawning()
    {
        Debug.Log("Start Spawning");
        InitializeSpawner();
        EnemiesByWave();
    }

    void InitializeSpawner()
    {
        _waveComplete = false;
        _spawnLevels++;
    }

    void EnemiesByWave()
    {
        Debug.Log("Enemies By Wave: " + _spawnLevels);

        switch (_spawnLevels)
        {
            case 1:
                _enemyType01 = 1;
                _enemyType02 = 2;
                _enemyType03 = 3;
                _enemyType04 = 4;
                break;
            case 2:
                _enemyType01 = 1;
                _enemyType02 = 3;
                _enemyType03 = 0;
                _enemyType04 = 1;
                break;
            case 3:
                _enemyType01 = 1;
                _enemyType02 = 2;
                _enemyType03 = 3;
                _enemyType04 = 0;
                break;
            case 4:
                //_enemyType01 = 10;
                //_enemyType02 = 10;
                //_enemyType03 = 0;
                //_enemyType04 = 0;
                break;
            case 5:
                //_enemyType01 = 10;
                //_enemyType02 = 10;
                //_enemyType03 = 10;
                //_enemyType04 = 0;
                break;
            case 6:
                //_enemyType01 = 10;
                //_enemyType02 = 10;
                //_enemyType03 = 10;
                //_enemyType04 = 0;
                break;
            case 7:
                //_enemyType01 = 10;
                //_enemyType02 = 10;
                //_enemyType03 = 10;
                //_enemyType04 = 10;
                break;
            case 8:
                //_enemyType01 = 10;
                //_enemyType02 = 10;
                //_enemyType03 = 10;
                //_enemyType04 = 10;
                break;

            default:
                break;
        }
        StartCoroutine(SpawnEnemyTimer());
    }

    IEnumerator SpawnEnemyTimer()
    {
        
        Debug.Log("Spawn Enemy Timer");
        if (_enemyType01 != 0)
        {
            for (int i = 0; i < _enemyType01; i++)
            {
                _totalEnemies++; 
                var newPosition = new Vector3(0, 2, Random.Range(-4, 4.0f));

                var enemy = Instantiate(_enemyPrefabs[0], newPosition, Quaternion.identity);
                yield return new WaitForSeconds(_spawnDelay);
            }
        }

        if (_enemyType02 != 0)
        {
            for (int i = 0; i < _enemyType02; i++)
            {
                _totalEnemies++; 
                var newPosition = new Vector3(0, 2, Random.Range(-4, 4.0f));

                var enemy = Instantiate(_enemyPrefabs[1], newPosition, Quaternion.identity);
                yield return new WaitForSeconds(_spawnDelay);
            }
        }

        if (_enemyType03 != 0)
        {
            for (int i = 0; i < _enemyType03; i++)
            {
                _totalEnemies++; 
                var newPosition = new Vector3(0, 2, Random.Range(-4, 4.0f));

                var enemy = Instantiate(_enemyPrefabs[2], newPosition, Quaternion.identity);
                yield return new WaitForSeconds(_spawnDelay);
            }
        }

        if (_enemyType04 != 0)
        {
            for (int i = 0; i < _enemyType04; i++)
            {
                _totalEnemies++; 
                var newPosition = new Vector3(0, 2, Random.Range(-4, 4.0f));

                var enemy = Instantiate(_enemyPrefabs[3], newPosition, Quaternion.identity);
                yield return new WaitForSeconds(_spawnDelay);
            }
        }
     
    }


//ENEMY COUNT REDUCTION
    public void ReduceEnemyCount()
    {
        Debug.Log("Reducing Enemy Count");

        _deadEnemy++;
        Debug.Log(_enemiesActive.ToString() + _waveComplete.ToString());
        if (_enemiesActive <= 1 && _waveComplete == false)
        {
            _waveComplete = true;
            _waveManager.AdvanceToNextWave();
        }        
    }   
}
