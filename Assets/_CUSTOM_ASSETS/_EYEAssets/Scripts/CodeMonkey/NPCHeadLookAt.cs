using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class NPCHeadLookAt : MonoBehaviour
{
    [SerializeField] private Rig _rig;
    [SerializeField] private Transform _headLookAtTransform;

    private bool _isLookingAtPosition;


    void Update()
    {
        float targetWeight = _isLookingAtPosition ? 1.0f : 0.0f;
        float lerpSpeed = 2.0f;
        _rig.weight = Mathf.Lerp(_rig.weight, targetWeight, Time.deltaTime * lerpSpeed);
    }

    public void LookAtPosition(Vector3 lookAtPosition)
    {
        _isLookingAtPosition= true;
        _headLookAtTransform.position = lookAtPosition;
    }
}
