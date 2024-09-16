using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EYE_Assets
{
    [RequireComponent(typeof(AudioSource))]
    public class Collectable_Inventory : MonoBehaviour
    {
        Audio_Manager _audioManager;
        UI_HUDManager _uiManager;

        [SerializeField] public string _objectName;

        [SerializeField] int _audioClipToPlay = 3;

        [SerializeField] bool _isKey;
        [SerializeField] bool _isTool;
        [SerializeField] bool _isWeapon;


    //BUILT-IN FUNCTIONS
        void Start()
        {
            _uiManager = FindObjectOfType<UI_HUDManager>();
            _audioManager = FindObjectOfType<Audio_Manager>();
        }


    //TRIGGER FUNCTIONS
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Player_KeyInventory _keyring = other.GetComponent<Player_KeyInventory>();
                Player_Inventory _inventory = other.GetComponent<Player_Inventory>();

                if (_keyring != null)
                {
                    if (_isKey)
                    {
                        if (_keyring != null)
                        {
                            _keyring.AddKeyToKeyring(gameObject.name);
                            Debug.Log("Picked Up " + _objectName);
                            _uiManager.UpdatePlayerMessage($"Picked Up {_objectName}");
                        }
                    }
                }
                
                if (_inventory != null)
                {
                    if (_isTool)
                    {
                        _inventory.AddToolToTools(gameObject);
                    }
                    
                    else if (_isWeapon)
                    {
                            _inventory.AddWeaponToWeapons(gameObject);
                    }

                    else if(_isKey == false)
                    {
                        _inventory.AddItemToInventory(gameObject);
                        gameObject.SetActive(false); 
                    }
                }
                
                _audioManager.PlayGeneralTrack(_audioClipToPlay);
                gameObject.SetActive(false);
            }
        }
    }
}