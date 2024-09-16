using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundCameraFollower : MonoBehaviour
{
    [SerializeField] private Camera _targetCamera;
    [SerializeField] private float _offset;

    private void Update()
    {
        var targetTransform = _targetCamera.transform;
        transform.position = new Vector3(targetTransform.position.x, targetTransform.position.y, _offset);
    }
}
