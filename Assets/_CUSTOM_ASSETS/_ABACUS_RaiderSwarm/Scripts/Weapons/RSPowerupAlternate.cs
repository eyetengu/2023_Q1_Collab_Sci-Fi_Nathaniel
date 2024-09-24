using RaiderSwarm.Enums;
using RaiderSwarm.Manager;
using RaiderSwarm.Player;
using System.Collections;
using UnityEngine;
namespace RaiderSwarm.Powerup
{

    public class RSPowerupAlternate : MonoBehaviour
    {
        [SerializeField] private float duration = 5f; // Duration of the powerup effect
        [SerializeField] private GameObject visuals;

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
                RSPlayer.Instance.hasAlternatePowerup = true;
                RSGameManager.Instance.UpdateAltWeapon(RSAlternateFireTypes.Missile);
                visuals.SetActive(false);
                var boxCollider = GetComponent<BoxCollider>();
                boxCollider.enabled = false;

                yield return new WaitForSeconds(duration);

                RSPlayer.Instance.hasAlternatePowerup = false;
                RSGameManager.Instance.UpdateAltWeapon(RSAlternateFireTypes.Bomb);
                Destroy(gameObject);
            }
        }
    }
}
