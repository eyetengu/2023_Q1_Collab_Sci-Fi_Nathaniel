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

    enum RequiredKeys { None, Bridge, Engineering, Medical, Science }
    RequiredKeys _keyToUnlock;

    [SerializeField] bool _requiresKey;
    [SerializeField] string _keyRequired;


    //[SerializeField] bool _scienceKeyRequired;
    //[SerializeField] bool _medicalKeyRequired;
    //[SerializeField] bool _engineKeyRequired;
    //[SerializeField] bool _bridgeKeyRequired;

    private void Update()
    {
        
    }

    void Key_FSM()
    {
        switch (_keyToUnlock) { 
            case RequiredKeys.None:
                _keyRequired = "General";
                break;
            case RequiredKeys.Bridge:
                _keyRequired = "Bridge";
                break;
            case RequiredKeys.Engineering:
                _keyRequired = "Engineering";
                break;
            case RequiredKeys.Science:
                _keyRequired = "Science";
                break;
            case RequiredKeys.Medical: 
                _keyRequired = "Medical";
                break;
            default:
                break;
    }
    }

    private void OnTriggerEnter(Collider other)
    {
        if((other.tag == "Player" || other.tag == "Maintenance") && _isOpen == false)
        {
            if (_requiresKey)
            {
                var keyInventory = other.GetComponent<Player_KeyInventory>();
                foreach (var key in keyInventory._keys)
                { 
                    //check players inventory and compare with _keyRequired
                    if (_keyRequired == key)
                    {
                        Debug.Log("Key Accepted");
                        _isOpen = true;
                        _doorModel.gameObject.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("Access Denied");
                    } 
                }
            }
            else
            {
                Debug.Log("Door Opening");
                _isOpen = true;
                _doorModel.gameObject.SetActive(false);
            }
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if((other.tag == "Player" || other.tag == "Maintenance") && _isOpen)
        {
            _doorModel.gameObject.SetActive(true);
            _isOpen = false;
        }
    }

}
