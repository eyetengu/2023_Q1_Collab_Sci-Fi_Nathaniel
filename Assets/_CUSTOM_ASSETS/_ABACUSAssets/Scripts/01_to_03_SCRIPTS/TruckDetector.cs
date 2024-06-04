using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckDetector : MonoBehaviour
{
    private Animator mAnimator;

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mAnimator.SetBool("boolProcessing", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mAnimator.SetBool("boolProcessing", false);
        }

    }
}
