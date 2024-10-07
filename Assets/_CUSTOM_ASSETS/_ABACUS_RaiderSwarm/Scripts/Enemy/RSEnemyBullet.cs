using RaiderSwarm.Manager;
using RaiderSwarm.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSEnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == RSPlayer.Instance.gameObject) 
        {
            Destroy(other.gameObject);
            RSGameManager.Instance.GameOver();
        }
    }
}
