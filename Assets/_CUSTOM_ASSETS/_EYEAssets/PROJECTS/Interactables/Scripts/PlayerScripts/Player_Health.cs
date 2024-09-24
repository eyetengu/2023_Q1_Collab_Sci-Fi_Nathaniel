using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour, IDamageable, IHealable, IHealthIncrease
{
    public delegate void PlayerHasDied();
    public static event PlayerHasDied playerHasDied;


    [SerializeField] GameObject _splatScreen;


//HEALTH
    public int maxHealth = 100;
    public int health;

   
//PROPERTIES
    public int Health { get; set; }

    public int HealthMax { get; set; }

    void Start()
    {
        Health = maxHealth;
    }

//INTERFACE FUNCTIONS
    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        HealthCheck();
    }

    public void Heal(int healthAmount)
    {
        health += healthAmount;
        HealthCheck();
    }
    
    public void IncreaseMaxHealth(int healthIncrease)
    {
        maxHealth += healthIncrease;
    }
    

//CORE FUNCTIONS
    void HealthCheck()
    {
        if (health < 0)
        {
            health = 0;
            if (playerHasDied != null)
                playerHasDied();

            _splatScreen.SetActive(true);
        }
        else
            _splatScreen.SetActive(false);

        if (health > maxHealth)
            health = maxHealth;
    }

}
