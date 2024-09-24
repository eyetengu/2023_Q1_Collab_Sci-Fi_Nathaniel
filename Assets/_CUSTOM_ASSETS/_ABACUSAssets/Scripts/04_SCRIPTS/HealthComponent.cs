using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int _health = 0;
    [SerializeField] private int MaxHealth = 10;
    public int Health { get => _health; }
    private const int _minHealth = 0;

    public void Start()
    {
        _health = MaxHealth;
    }
    public void Heal(int healing)
    {
        if (_health + healing >= MaxHealth)
        {
            _health = MaxHealth;
            return;
        }
        _health += healing;

    }
    public void Damage(int damage)
    {
         if (damage < 0)
        {
            Heal(damage);
        }
        if(damage > _health)
        {
            _health -= _health;
        }
        else
        {
            _health -= damage;
        }
        CheckIfDead();
    }

    private void CheckIfDead()
    {
        if (_health <= _minHealth)
        {
            Destroy(gameObject);
        }
    }
}
