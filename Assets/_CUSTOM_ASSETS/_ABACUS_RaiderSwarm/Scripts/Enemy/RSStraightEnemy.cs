using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSStraightEnemy : MonoBehaviour
{
    public float speed = 50f;

    void Update()
    {
        // Move the enemy to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
