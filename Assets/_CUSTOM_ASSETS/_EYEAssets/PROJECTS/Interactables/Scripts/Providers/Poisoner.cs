using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poisoner : MonoBehaviour
{
    [SerializeField] bool isPoisoned;
    [SerializeField] float poisonSpeed;
    [SerializeField] int poisonPower;


    private void OnTriggerEnter(Collider other)
    {
        Player_PoisonControl _playerPoison = other.GetComponent<Player_PoisonControl>();
        if(other.tag== "Player" && _playerPoison != null)
        {
            _playerPoison.PlayersPoisonControl(isPoisoned, poisonSpeed, poisonPower);
        }
    }
}
