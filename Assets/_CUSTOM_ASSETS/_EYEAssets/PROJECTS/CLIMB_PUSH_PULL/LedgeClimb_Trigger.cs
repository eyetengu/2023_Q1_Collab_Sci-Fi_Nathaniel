using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeClimb_Trigger : MonoBehaviour
{
    Climbing_Player _climbingPlayer;



    void Start()
    {
        _climbingPlayer = GetComponentInParent<Climbing_Player>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ledge")
        {
            Debug.Log("Detected Ledge " + gameObject.name);
            _climbingPlayer.PlayerIsMountingLedge();
        }
    }
 
}
