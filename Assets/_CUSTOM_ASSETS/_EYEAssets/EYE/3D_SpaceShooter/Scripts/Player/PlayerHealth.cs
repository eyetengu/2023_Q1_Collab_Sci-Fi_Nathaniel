using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [Header("MANAGERS")]
    UIManager _uiManager;
    GameManager _gameManager;
    [SerializeField] private AudioManager_3DSpace _audioManager;
    private WaveManager _waveManager;

    [Header("GAME OBJECTS")]
    [SerializeField] private GameObject _playerModel;
    [SerializeField] GameObject _playerExplosion;

    [Header("PLAYER HEALTH")]
    [SerializeField] int _playerMaxHealth = 5;
    int _playerHealth;
    int collisionCount;

    //PROPERTIES
    public int Health { get; set; }
    


    void Start()
    {
        _audioManager = GameObject.FindObjectOfType<AudioManager_3DSpace>();
        _uiManager  = GameObject.FindObjectOfType<UIManager>();
        _waveManager = GameObject.FindObjectOfType<WaveManager>();
        _gameManager= GameObject.FindObjectOfType<GameManager>();

        _uiManager.UpdatePlayerHealthBar(Health);
        _uiManager.SliderSetMaxValue(_playerMaxHealth);
        
        Health = _playerMaxHealth;
        _uiManager.UpdatePlayerHealthBar(Health);
    }

    void Damage()
    {
        HealthCheck();
    }

    public void Damage(int damageAmount)
    {
        Health -= damageAmount;
        HealthCheck();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Health = 0;
            HealthCheck();
        }
    }

    void HealthCheck()
    {
        var message = "";

        if (Health <= 0)
        {
            _gameManager.Died = true;
            //message = "Player Is Dead";
            _uiManager.ClearPlayerMessage();
            _uiManager.DisplayGameOverPanel();
            _playerModel.SetActive(false);
            StartCoroutine(ReproducePlayerCraft());
        }
        else if (Health >= 1)
        {
            //message = "Player is Fine...";
            //_uiManager.UpdatePlayerMessage(message);        
        }

        _uiManager.UpdatePlayerHealthBar(Health);    
        //_audioManager.PlayGameOver();
        //Debug.Log(message);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlanetoidBehavior planetoid = other.GetComponent<PlanetoidBehavior>();
        CollectableBehavior collectable = other.GetComponent<CollectableBehavior>();
        //EnemyBehavior enemy = other.GetComponent<EnemyBehavior>();
        Enemy_V2 enemy = other.GetComponent<Enemy_V2>();
        FallingObjects fallingObjects = other.GetComponent<FallingObjects>();

        if (planetoid != null)
        {
            //Damage(Health);
            //take damage
            //disable other
        }

        if (collectable != null)
        {
            Damage(-1);
            _audioManager.PickupAudio();
            //add points to score
            //disable collectable
        }

        if (enemy != null)
        {
            Damage(1);
            StartCoroutine(ExplosionTimer());
            
            _audioManager.ExplosionAudio();
            _playerExplosion.SetActive(true);

            //take damage
            //disable enemy
        }

        if (fallingObjects != null)
        {
            collisionCount++;
            Debug.Log("Collisions: " + collisionCount);
        }
    }

    IEnumerator ReproducePlayerCraft()
    {
        yield return new WaitForSeconds(3);
        _playerExplosion.SetActive(false);
        //_playerModel.SetActive(true);
    }

    IEnumerator ExplosionTimer()
    {
        yield return new WaitForSeconds(.2f);
        _playerExplosion.SetActive(false);
    }
}
