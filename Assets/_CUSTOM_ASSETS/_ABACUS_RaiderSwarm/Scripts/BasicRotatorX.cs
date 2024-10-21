using RaiderSwarm.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RaiderSwarm.Functions

{

    public class BasicRotatorX : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 10f;

        void Update()
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        }
    }
}