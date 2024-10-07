using RaiderSwarm.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RaiderSwarm.Functions
{
    public class FacePlayer : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 5f; // Adjust the rotation speed as needed

        void Update()
        {
            // Calculate the direction from the object to the player
            Vector3 direction = RSPlayer.Instance.transform.position - transform.position;

            // Calculate the rotation needed to look at the player
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Smoothly rotate the object towards the player
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
