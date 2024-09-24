using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace RaiderSwarm.Functions
{

    public class GameobjectFollower : MonoBehaviour
    {
        [SerializeField] private GameObject _targetCamera;
        [SerializeField] private float _offsetZ;
        [SerializeField] private float _offsetY;
        [SerializeField] private float _offsetX;

        private void Update()
        {
            var targetTransform = _targetCamera.transform;
            transform.position = new Vector3(targetTransform.position.x + _offsetX, targetTransform.position.y + _offsetY, _offsetZ);
        }
    }
}
