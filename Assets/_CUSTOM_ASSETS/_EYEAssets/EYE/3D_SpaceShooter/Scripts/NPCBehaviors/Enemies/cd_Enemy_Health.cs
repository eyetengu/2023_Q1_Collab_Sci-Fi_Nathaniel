using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cd_Enemy_Health : MonoBehaviour, IDamageable
{
    [Header("VFX")]
    [SerializeField] private GameObject _bulletFX;
    [SerializeField] private GameObject _fireFX;
    [SerializeField] private GameObject _explosionFX;

    AudioManager_3DSpace _audioManager;
    NewSpawnManager _spawnManager;


//PROPERTIES
    public int Health { get; set; }


//BUILT-IN FUNCTIONS
    void Start()
    {
        _spawnManager = GameObject.FindObjectOfType<NewSpawnManager>();
        _audioManager = GameObject.FindObjectOfType<AudioManager_3DSpace>();
        Health = 5;
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
            Debug.Log("BOOM!");

            Damage(1);
            _bulletFX.SetActive(true);
            StartCoroutine(BulletFXTimer());
            _audioManager.PlayBulletMetalRicochet();

            if (Health <= 0)
            {
                Event_Manager.Instance.Score_Increase();
                _fireFX.SetActive(false);
                _bulletFX.SetActive(false);
                _explosionFX.SetActive(true);

                StartCoroutine(DisableCraftTimer());
                //GameManager.Instance.GetComponent<ScoreManager>().SetScore(_score);
                _spawnManager.EnemyDies();
            }
            if (Health <= 3)
            {
                _fireFX.SetActive(true);
            }
        }
    }
}
