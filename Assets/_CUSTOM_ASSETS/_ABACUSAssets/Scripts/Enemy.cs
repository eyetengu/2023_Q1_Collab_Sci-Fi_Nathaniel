using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
