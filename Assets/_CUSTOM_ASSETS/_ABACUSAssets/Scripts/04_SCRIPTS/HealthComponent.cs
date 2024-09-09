using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int Health = 0;
    [SerializeField] private int MaxHealth = 10;

    private const int _minHealth = 0;

    public void Start()
    {
        Health = MaxHealth;
    }
    public void Heal(int healing)
    {
        if (Health + healing >= MaxHealth)
        {
            Health = MaxHealth;
            return;
        }
        Health += healing;

    }
    public void Damage(int damage)
    {
        if (damage < 0)
        {
            Heal(damage);
        }
        if(damage > Health)
        {
            Health -= Health;
            return;
        }
        else
        {
            Health -= damage;
        }
        CheckIfDead();
    }

    private void CheckIfDead()
    {
        if (Health <= _minHealth)
        {
            Destroy(gameObject);
        }
    }
}
