using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingCharacter : MonoBehaviour
{
    [SerializeField] float _speed = 2.0f;
    float _step;
    [SerializeField] private Transform _maxXTransform;
    [SerializeField] private Transform _originXTransform;


    void Update()
    {
        _step = _speed * Time.deltaTime;

        PlayerWalk();
    }

    void PlayerWalk()
    {
        transform.position = Vector3.MoveTowards(transform.position, _maxXTransform.position, _step);
        if(transform.position == _maxXTransform.position)
            transform.position = _originXTransform.position;
    }

}
