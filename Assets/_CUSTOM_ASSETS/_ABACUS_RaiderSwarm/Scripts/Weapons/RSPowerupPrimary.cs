using RaiderSwarm.Enums;
using RaiderSwarm.Manager;
using RaiderSwarm.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RaiderSwarm.Powerup
{

    public class RSPowerupPrimary : MonoBehaviour
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
                RSPlayer.Instance.hasPrimaryPowerup = true;
                RSGameManager.Instance.UpdateWeapon(RSWeaponType.BIGLAZER);
                Visuals.SetActive(false);
                var boxCollider = GetComponent<BoxCollider>();
                boxCollider.enabled = false;

                yield return new WaitForSeconds(duration);

                RSPlayer.Instance.hasPrimaryPowerup = false;
                RSGameManager.Instance.UpdateWeapon(RSWeaponType.BULLET);
                Destroy(gameObject);
            }
        }
    }
}
