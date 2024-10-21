using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RaiderSwarm.Enemy
{
    public class RSTurretEnemy : MonoBehaviour
    {
        [SerializeField] private float Seconds = 0.6f;
        [SerializeField] private GameObject objectToInstantiate; // The GameObject to instantiate

        private void Start()
        {
            // Start the coroutine
            StartCoroutine(InstantiateObjectCoroutine());
        }

        private IEnumerator InstantiateObjectCoroutine()
        {
            while (true)
            {
                // Wait for 0.3 seconds
                yield return new WaitForSeconds(Seconds);

                // Calculate the position in front of the current object
                Vector3 instantiatePosition = transform.position + transform.forward;

                // Instantiate the object at the calculated position
                Instantiate(objectToInstantiate, instantiatePosition, transform.rotation);
            }
        }
    }
}