using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RaiderSwarm.Functions
{

    public class BasicRotatorY : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 10f;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
    }
}
