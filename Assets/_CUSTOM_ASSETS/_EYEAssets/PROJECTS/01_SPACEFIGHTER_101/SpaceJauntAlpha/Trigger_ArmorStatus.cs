using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_ArmorStatus : MonoBehaviour
{
    private int _health;
    private int _maxHealth = 20;

    [SerializeField] GameObject[] _flamePoints;

    [SerializeField] GameObject _explosionPrefab;

    bool _hasExploded;


    public int Health { get; set; }


    void Start()
    {
        Health = _maxHealth;
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Projectile")
        {
            Health -= 1;
            if (Health <= 0)
            {
                if (_hasExploded == false)
                {
                    _hasExploded = true;
                    var explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
                    explosion.transform.localScale = Vector3.one * 5;
                    Destroy(gameObject, 1.0f);
                }
            }
            else if (Health < 5)
                _flamePoints[2].SetActive(true);
            else if (Health < 10)
                _flamePoints[1].SetActive(true);
            else if (Health < 15)
                _flamePoints[0].SetActive(true);
        }
    }
}
