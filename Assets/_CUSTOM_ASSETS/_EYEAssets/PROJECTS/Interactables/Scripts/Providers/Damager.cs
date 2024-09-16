using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [Header("DAMAGE AMOUNT")]
    [SerializeField] int _damageAmount = 10;
    private void OnTriggerEnter(Collider other)
    {
        var damageInterface = other.GetComponent<IDamageable>();
        if (damageInterface != null)
            damageInterface.Damage(_damageAmount);
    }
}
