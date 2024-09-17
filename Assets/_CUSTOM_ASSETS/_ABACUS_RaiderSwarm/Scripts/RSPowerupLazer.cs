using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSPowerupLazer : MonoBehaviour
{
    [SerializeField] private float duration = 5f; // Duration of the powerup effect
    [SerializeField] private GameObject Visuals;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == RSPlayer.Instance.gameObject)
        {
            StartCoroutine(Pickup());
        }
    }

    IEnumerator Pickup()
    {
        if (RSPlayer.Instance != null)
        {
            RSPlayer.Instance.hasLazerPowerup = true;
            RSGameManager.Instance.UpdateWeapon(RSWeaponType.BigBullet);
            Visuals.SetActive(false);


            yield return new WaitForSeconds(duration);

            RSPlayer.Instance.hasLazerPowerup = false;
            RSGameManager.Instance.UpdateWeapon(RSWeaponType.Bullet);
            Destroy(gameObject);
        }
    }
}
