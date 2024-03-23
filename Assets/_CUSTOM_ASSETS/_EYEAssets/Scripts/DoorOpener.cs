using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private Animator _doorAnimator;
    [SerializeField] bool _isDoorOpen;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_isDoorOpen == false)
            {
                _isDoorOpen = true;

                Debug.Log("Open");
                _doorAnimator.SetBool("Open", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_isDoorOpen)
            {
                _isDoorOpen= false;

                Debug.Log("Close");
                _doorAnimator.SetBool("Open", false);
            }
        }
    }
}
