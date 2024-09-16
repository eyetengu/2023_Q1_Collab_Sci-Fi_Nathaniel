using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var healingInterface = other.GetComponent<IHealable>();
        if (healingInterface != null)
            healingInterface.Heal(10);
    }
}
