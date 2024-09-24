using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSNavigateToPlayer : MonoBehaviour
{
    [SerializeField] private float _followSpeed = 2f;
    void Update()
    {
        if (RSPlayer.Instance != null)
        {
            // Move the powerup towards the player
            transform.position = Vector3.MoveTowards(transform.position, RSPlayer.Instance.transform.position, _followSpeed * Time.deltaTime);
        }
    }

}
