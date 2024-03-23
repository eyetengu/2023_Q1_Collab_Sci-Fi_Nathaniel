using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Trigger : MonoBehaviour
{
    [SerializeField] Animator _animator;
    

    private void OnTriggerEnter(Collider other)
    {
        _animator.SetTrigger("Open");
    }
    private void OnTriggerExit(Collider other)
    {
        _animator.SetTrigger("Close");
    }
}
