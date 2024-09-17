using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RSPlayerCameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private const float SMOOTHING_WEIGHT = 0.125f;
    [SerializeField] private float _distanceFromPlayerX;
    [SerializeField] private float _distanceFromPlayerZ;

    // Update is called once per frame
    void Update()
    {
        if (RSPlayer.Instance != null) {
            var playerTransform = RSPlayer.Instance.transform;
            var targetPosition = new Vector3(playerTransform.position.x + _distanceFromPlayerX, transform.position.y, playerTransform.position.z + _distanceFromPlayerZ);
            transform.position = targetPosition; }
    }
}
