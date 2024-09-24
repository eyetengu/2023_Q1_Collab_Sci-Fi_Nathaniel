using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncreaser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var healthIncreaseInterface = other.GetComponent<IHealthIncrease>();
        if (healthIncreaseInterface != null)
            healthIncreaseInterface.IncreaseMaxHealth(10);
    }
}
