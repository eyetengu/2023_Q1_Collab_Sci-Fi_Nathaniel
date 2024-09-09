using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RSPlayerCameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private const float SMOOTHING_WEIGHT = 0.125f;

    // Update is called once per frame
    void Update()
    {
        var playerTransform = RSPlayer.Instance.transform;
        var targetPosition = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, SMOOTHING_WEIGHT);
    }
}
