using EYE_Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorDialog : MonoBehaviour
{
    Quest_Manager _questManager;
    UI_HUDManager _UIManager;
    
    Player_Inventory _playerInventory;
    Inventory_Manager _inventoryManager;

    Animator _animator;

    //QUEST DATA
    [Header("Quest Data")]
    [SerializeField] private string _questName;
    [SerializeField] private string _rewardName;    
    [SerializeField] private List<string> _quest_TODOs = new List<string>();    
    

    [SerializeField] private GameObject _rewardObject;
    [SerializeField] private GameObject _questIcon;

    //DIALOG DATA
    [Header("Dialog Elements")]
    [SerializeField] private string _introDialog;
    [SerializeField] private string _informationDialog;
    [SerializeField] private string _acceptDialog;
    [SerializeField] private string _questCompleteDialog;

    SkinnedMeshRenderer _vendorRenderer;

    string _message;
    int itemsCollected;

    public bool _inZone;
    public bool _questExplained;
    public bool _questAccepted;
    public bool _questComplete;
    public bool _finalDialogFinished;

    float _rotationSpeed = 2.0f;
    float _rotationStep;

    [SerializeField] private Material[] _questIconColors;
    private MeshRenderer _questIconRenderer;
    Player_Inventory _newPlayerInventory;






    //BUILT-IN FUNCTIONS
    private void Start()
    {
        _questManager = FindObjectOfType<Quest_Manager>();        
        _UIManager = FindObjectOfType<UI_HUDManager>();
        _vendorRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        _animator = GetComponentInChildren<Animator>();
        _questIconRenderer = _questIcon.GetComponent<MeshRenderer>();
        _questIconRenderer.material = _questIconColors[0];
        _inventoryManager = FindObjectOfType<Inventory_Manager>();
    }

    void Update()
    {
        _rotationStep = _rotationSpeed * Time.deltaTime;

        if (_inZone)
        {
            TurnToFacePlayer();
            if (_questComplete == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(_questAccepted == false)
                    {
                        if (_questExplained == false)                        
                            ExplainQuest();                                                    
                        else if (_questExplained)
                        {
                            AcceptQuest();     
                        }
                    }
                    else if (_questAccepted)                                                                    //When the player accepts the vendor's quest
                    {
                        PerformInventoryCheckForItems();
                    }
                } 
            }            
        }        
    }

    void ExplainQuest()
    {
        _questExplained = true;

        string requestItems = " ";
        foreach (var item in _quest_TODOs)
            requestItems += item.ToString() + ", ";

        _message = _informationDialog + requestItems;

        _UIManager.UpdatePlayerMessage(_message);
        Debug.Log(_informationDialog + requestItems);
    }

    void AcceptQuest()
    {
        _message = _acceptDialog;
        Debug.Log(_acceptDialog);

        _questExplained = true;

        _questAccepted = true;
        _playerInventory.AddQuestToList(_questName);
        _questManager.AddActiveQuest(_questName);

        _UIManager.UpdatePlayerMessage(_message);

        _questIconRenderer.material = _questIconColors[1];
    }

    void PerformInventoryCheckForItems()
    {
        itemsCollected = 0;            //The number of quest objective items collected is reset to zero

                Debug.Log("Inside the first foreach"+_quest_TODOs.Count);
        if (_quest_TODOs.Count > 0)
        {
            foreach (string todo in _quest_TODOs)                                                   //The vendor's quest objective is obtained...
            {
                string objectInToDoList = todo;
                if (objectInToDoList == null)
                    Debug.Log("No 1st Item");



                List<GameObject> playerInventory = _playerInventory._items;           //A list of the player's inventory items is collected

                foreach (GameObject item2 in playerInventory)                                        //The player's inventory list is compared to the vendor's list
                {
                    Debug.Log(":" + todo + "/" + item2);

                    var objectInPlayerInventory = item2.GetComponent<Collectable_Inventory>();
                    if (objectInPlayerInventory == null)
                        Debug.Log("No 2nd Item");                

                    //Assuming we have a match: -increase Items collected, -remove item from players inventory, -check to see if all quest objectives are complete
                    if (objectInToDoList == objectInPlayerInventory.gameObject.name)                    //if there is a match...
                    {
                        _playerInventory.RemoveItemFromInventory(item2);                    //The item that matches is removed from the player's inventory
                        itemsCollected++;                                                   //The number of collected items is increased

                        if (itemsCollected == _quest_TODOs.Count)                           //If all vendor items are collected...
                        {
                            PerformQuestCompleteFunctions();
                            return;                                                         //exit _questAccepted condition
                        }
                        break;                                                              //if items match- continue foreach(GO item2 in gameObjectInventory) loop
                    }
                }
            }
        }
    }

    void PerformQuestCompleteFunctions()
    {
        _questComplete = true;                                                  //This quest is marked complete
        _finalDialogFinished = true;                                            //The final dialog is marked as finished

        _animator.SetBool("Item Received", true);                               //The vendor's 'quest finished' animation is triggered

        _questManager.AddCompletedQuest(_questName);                            //The quest is added(completed quest list) & removed(active quest list) (Quest MGR)

        _playerInventory.RemoveQuestFromList(_questName);

        //_playerInventory.AddItemToPlayerInventory(_rewardObject);             //Reward item added to player's inventory
        _newPlayerInventory.AddItemToInventory(_rewardObject);
        _message = _questCompleteDialog + " " + _rewardName + " I promised";    //Message created
        _UIManager.UpdatePlayerMessage(_message);                               //Message sent to UI_Manager to be displayed in player message area
        Debug.Log(_questCompleteDialog);

        _questIcon.SetActive(false);                                            //Quest Icon is removed from above player's head
    }


//CORE FUNCTIONS
    void TurnToFacePlayer()
    {
        Vector3 targetDirection = _playerInventory.gameObject.transform.position - transform.position;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, _rotationStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }


//TRIGGER FUNCTIONS
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _playerInventory = other.GetComponent<Player_Inventory>();
            _newPlayerInventory = other.GetComponent<Player_Inventory>();

            _inZone = true;
            
            if(_questAccepted == false)
            {
                _message = _introDialog;
                _UIManager.UpdatePlayerMessage(_message);
                Debug.Log(_introDialog);
            }
            else if (_questAccepted)
            {
                _message = "Let's Check to see if you have it all";
                _UIManager.UpdatePlayerMessage(_message);
                Debug.Log(_message);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && _questAccepted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _message = "HMMM. It's right about here we need to check if the quest is complete";
                _UIManager.UpdatePlayerMessage(_message);
                Debug.Log(_message);

                PerformInventoryCheckForItems();
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            _inZone = false;
    }
}
