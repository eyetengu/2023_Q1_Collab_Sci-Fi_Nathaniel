using RaiderSwarm.Interfaces;
using RaiderSwarm.Manager;
using RaiderSwarm.Player;
using RaiderSwarm.Powerup;
using System;
using UnityEngine;

public class RSTarget : MonoBehaviour, IRSEnemy
{
    private RSActivator _activator;
    private HealthComponent _healthComponent;
    [SerializeField] private bool ignorePlayer = false;
    public void TakeDamage(int damage)
    {
        _healthComponent.Damage(damage);
    }

    private void Awake()
    {
        _healthComponent = GetComponent<HealthComponent>();
        _activator = GetComponent<RSActivator>();
    }

    private void OnEnable()
    {
        _healthComponent.OnDeath += _healthComponent_OnDeath;
    }
    private void OnDisable()
    {
        _healthComponent.OnDeath -= _healthComponent_OnDeath;
    }
    private void _healthComponent_OnDeath()
    {
        if (RSGameManager.Instance != null)
        {
            var itemDropComponent = GetComponent<RSPowerupDropper>();
            if (itemDropComponent != null)
            {
                itemDropComponent.DropPowerUp();
            }
            RSGameManager.Instance.AddScore(3000);
            RSGameManager.Instance.ObjectiveCompleted();
            if (_activator != null)
            {

                _activator.ActivateGameObject();
            }
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == RSPlayer.Instance?.gameObject && !ignorePlayer)
        {
            RSPlayer.Instance.DestroyPlayer();
            

        }

        IDamage iDamage = other.gameObject.GetComponent<IDamage>();
        if (iDamage != null)
        {
            other.gameObject.SetActive(false);

            TakeDamage(iDamage.Damage);
        }
    }
}
