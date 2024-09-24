using System.Collections;
using System.Collections.Generic;
//using TMPro.EditorUtilities;
using UnityEngine;

public class QAndDItemPickup_V1 : MonoBehaviour
{    
    UI_Manager _uiManager;
    UI_MusicManager _musicUIManager;
    Audio_Manager _audioManager;

    public string _objectName;
    [SerializeField] AudioClip _audioClip;
    public Texture _image;

    [SerializeField] private bool _isEquipable;


    //BUILT-IN FUNCTIONS
    private void Start()
    {
        _audioManager = FindObjectOfType<Audio_Manager>();
        //_musicUIManager = FindObjectOfType<UI_MusicManager>();
        _uiManager = GameObject.FindObjectOfType<UI_Manager>();
        //_audioSource = GetComponent<AudioSource>();
    }

    public bool CheckIfItemIsEquipable()
    {
        if (_isEquipable)        
            return true;        
        else
            return false;
    }


    //TRIGGER FUNCTIONS
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _audioManager.PlayGeneralTrack(3);
            //_musicUIManager.PlayGeneralAudioClip(_audioClip);
            Debug.Log("Playing Audio Clip");
            var collider = gameObject.GetComponent<SphereCollider>();
            collider.enabled = false;

            var playerInventory = other.GetComponent<QuestPlayer_V1>();
            var newPlayerInventory = other.GetComponent<Player_Inventory>();
            //playerInventory._inventoryObject.Add(this.gameObject);

            if (_image != null)
            {
                //playerInventory.AddItemToPlayerInventory(this.gameObject);
                newPlayerInventory.AddItemToInventory(this.gameObject);
            }

            this.gameObject.SetActive(false);
        }
    }
}
