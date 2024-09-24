using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RaiderSwarm.Weapon
{

    public class RSBasicBomb : MonoBehaviour
    {
        public float speed = 1f;
        private float x = 0f;
        void Update()
        {
            // Increment x based on speed and time
            x += speed * Time.deltaTime;

            // Update the position of the game object
            transform.position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z);
        }
    }
}
