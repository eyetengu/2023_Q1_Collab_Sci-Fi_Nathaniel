using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors_SlideUp : MonoBehaviour
{
    [SerializeField] Transform[] _doors;
    bool _isOpen;
    [SerializeField] Vector3 origin = Vector3.zero;
    [SerializeField] Vector3 open = new Vector3(0, 3, 0);
    [SerializeField] Transform _doorModel;

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && _isOpen == false)
        {
            Debug.Log("Door Opening");
            _isOpen = true;
            _doorModel.gameObject.SetActive(false);
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" && _isOpen)
        {
            _doorModel.gameObject.SetActive(true);
            _isOpen = false;
        }
    }

}
