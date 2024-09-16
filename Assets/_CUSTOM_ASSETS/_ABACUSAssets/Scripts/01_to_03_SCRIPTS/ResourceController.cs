using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    public bool IsActiveDrill { get { return _isActiveDrill; } }
    private Animator mAnimator;
    private bool _isActiveDrill;

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (_isActiveDrill)
        {
            //Add resource to total
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _isActiveDrill = true;
            mAnimator.SetBool("boolProcessing", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //    _isActiveDrill = false;
        //    mAnimator.SetBool("boolProcessing", false);
        //}
    }
}
