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
    public void TakeDamage(int damage)
    {
        _healthComponent.Damage(damage);
    }

    private void Start()
    {
        _healthComponent = GetComponent<HealthComponent>();
        _activator = GetComponent<RSActivator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == RSPlayer.Instance?.gameObject)
        {
            Destroy(other.gameObject);
            if (RSGameManager.Instance != null)
            {
                RSGameManager.Instance.GameOver();
            }

        }

        IDamage iDamage = other.gameObject.GetComponent<IDamage>();
        if (iDamage != null)
        {
            Destroy(other.gameObject);

            TakeDamage(iDamage.Damage);
        }
    }

    private void OnDestroy()
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
            if (_activator != null) {

                _activator.ActivateGameObject();
            }
        }
    }

}
