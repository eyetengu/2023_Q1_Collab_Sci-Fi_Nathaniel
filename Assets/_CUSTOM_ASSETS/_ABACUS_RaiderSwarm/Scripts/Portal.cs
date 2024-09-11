using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private float _targetXPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject == RSPlayer.Instance.gameObject)
        {
            var playerPosition = other.transform.position;
            other.transform.position = new Vector3(_targetXPosition, playerPosition.y, playerPosition.z);
        }
    }
}
