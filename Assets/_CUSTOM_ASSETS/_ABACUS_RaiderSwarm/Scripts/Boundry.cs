using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundry : MonoBehaviour
{
    [SerializeField] private float _bumpOffset;

    private void OnCollisionEnter(Collision other)
    {
        if (other != null && other.gameObject == RSPlayer.Instance.gameObject)
        {
            var otherPosition = other.transform.position;
            other.transform.position = new Vector3(otherPosition.x, otherPosition.y + _bumpOffset, otherPosition.z);
        }

    }
}
