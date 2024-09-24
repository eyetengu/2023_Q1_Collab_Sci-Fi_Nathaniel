using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearmTriggerHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyTriggers;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == RSPlayer.Instance.gameObject)
        {
            foreach(var trigger in _enemyTriggers)
            {
                trigger.gameObject.SetActive(true);
            }
        }
    }
}
