using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cd_Enemy_Health : MonoBehaviour, IDamageable
{
    Enemy_Count_Manager _enemyCountManager;

    [Header("VFX")]
    [SerializeField] private GameObject _bulletFX;
    [SerializeField] private GameObject _fireFX;
    [SerializeField] private GameObject _explosionFX;

    [SerializeField] private bool _isEnemy;

    BoxCollider _boxCollider;
    SphereCollider _sphereCollider;
    AudioManager_3DSpace _audioManager;
    NewSpawnManager _spawnManager;


//PROPERTIES
    public int Health { get; set; }


//BUILT-IN FUNCTIONS
    void Start()
    {
        _enemyCountManager = FindObjectOfType<Enemy_Count_Manager>();
        _spawnManager = GameObject.FindObjectOfType<NewSpawnManager>();
        _audioManager = GameObject.FindObjectOfType<AudioManager_3DSpace>();
        _boxCollider = GetComponent<BoxCollider>();
        _sphereCollider = GetComponent<SphereCollider>();

        Health = 5;

        if(_boxCollider != null)
            _boxCollider.enabled = true;
        else
            _sphereCollider.enabled = true;
    }


//CORE FUNCTIONS
    public void Damage(int damageAmount)
    {
        Health -= damageAmount;
    }


//COROUTINES
    IEnumerator DisableCraftTimer()
    {
        yield return new WaitForSeconds(1.0f);
        this.gameObject.SetActive(false);
    }

    IEnumerator BulletFXTimer()
    {
        yield return new WaitForSeconds(.15f);
        _bulletFX.SetActive(false);
    }


//COLLISION FUNCTIONS
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            //Debug.Log("BOOM!");

            Damage(1);
            _bulletFX.SetActive(true);
            StartCoroutine(BulletFXTimer());
            _audioManager.PlayBulletMetalRicochet();

            if (Health <= 0)
            {
                Event_Manager.Instance.Score_Increase();

                if (_boxCollider != null)
                    _boxCollider.enabled = false;
                else
                    _sphereCollider.enabled = false;

                //ACTIVATE LOCAL COMPONENTS
                _fireFX.SetActive(false);
                _bulletFX.SetActive(false);
                _explosionFX.SetActive(true);

                StartCoroutine(DisableCraftTimer());
                //GameManager.Instance.GetComponent<ScoreManager>().SetScore(_score);
                if(_isEnemy)
                    _enemyCountManager.RemoveEnemy();
            }
            if (Health <= 3)
            {
                _fireFX.SetActive(true);
            }
        }
    }
}
