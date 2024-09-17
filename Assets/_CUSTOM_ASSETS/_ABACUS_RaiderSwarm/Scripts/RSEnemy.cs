using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSEnemy : MonoBehaviour, IRSEnemy
{
    private HealthComponent _healthComponent;

    public void TakeDamage(int damage)
    {
        _healthComponent.Damage(damage);
    }

    // Start is called before the first frame update
    void Start()
    {
        _healthComponent = GetComponent<HealthComponent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == RSPlayer.Instance?.gameObject) {
            Destroy(other.gameObject);
            RSGameManager.Instance.GameOver();
        }

        BasicLazerScript basicLazerScript = other.gameObject.GetComponent<BasicLazerScript>();
        if (basicLazerScript != null)
        {
            Destroy(other.gameObject);

            TakeDamage(basicLazerScript.Damage);
            if (_healthComponent.Health <= 0)
            {
                var itemDropComponent = GetComponent<RSPowerupDropper>();
                if (itemDropComponent != null)
                {
                    itemDropComponent.DropPowerUp();
                }
                if (RSGameManager.Instance != null)
                {
                    RSGameManager.Instance.AddScore(100);
                }
            }

        }
    }
}
