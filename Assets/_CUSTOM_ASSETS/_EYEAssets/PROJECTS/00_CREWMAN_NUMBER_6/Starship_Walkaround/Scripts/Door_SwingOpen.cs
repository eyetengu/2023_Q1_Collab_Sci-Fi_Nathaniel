using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_SwingOpen : MonoBehaviour
{
    [SerializeField] Transform _doorTransform;
    bool _isOpen;
    [SerializeField] float _doorOpenAngle = -120;
    [SerializeField] float _doorClosedAngle = 0;

    private void OnTriggerEnter(Collider other)
    {
        if((other.tag == "Player" || other.tag == "Maintenance") && _isOpen == false)
        {
            _doorTransform.Rotate(0, _doorOpenAngle, 0);
            _isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if((other.tag == "Player" || other.tag == "Maintenance") && _isOpen)
        {
            _doorTransform.Rotate(0, _doorClosedAngle, 0);
            _isOpen = false;
        }
    }
}
