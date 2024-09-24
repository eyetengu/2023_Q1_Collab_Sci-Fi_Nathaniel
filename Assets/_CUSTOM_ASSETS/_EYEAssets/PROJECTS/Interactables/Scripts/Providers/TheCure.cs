using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCure : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var poisonControl = other.GetComponent<Player_PoisonControl>();
        if(poisonControl != null)
        {
            poisonControl.PlayersPoisonControl(false, 0, 0);
        }
    }
}
