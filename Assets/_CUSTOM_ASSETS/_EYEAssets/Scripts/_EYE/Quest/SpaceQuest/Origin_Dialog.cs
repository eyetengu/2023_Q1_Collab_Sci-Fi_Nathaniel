using EYE_Assets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Origin_Dialog : MonoBehaviour
{
    Audio_Manager _audioManager;
    Origin_Quest _questScript;
    UI_HUDManager _uiHud;

    [SerializeField] GameObject _player;

    [Header("CONDITIONS")]
    [SerializeField] bool _inZone;
    [SerializeField] bool _questRelated;
    [SerializeField] bool _questCompleted;

    [Header("DIALOG")]
    [SerializeField] string _introDialog;
    [SerializeField] string[] _secondaryDialogOptions;
    [SerializeField] TMP_Text _dialogDisplay;
    [SerializeField] GameObject _dialogInstructions;

    [Header("QUEST STATUS ICON")]
    [SerializeField] GameObject _questStatusIcon;
    [SerializeField] MeshRenderer _renderer;
    [SerializeField] Material _iconColor1;
    [SerializeField] Material _iconColor2;

    [Header("LISTS")]
    [SerializeField] List<GameObject> _playerInventory;
    [SerializeField] List<GameObject> _todoList;

    bool _questAccepted;
    bool _questExplained;
    bool _hasDisplayedConclusion;

    int _dialogID;
    int _secondaryDialogID;
    int _numberOfQuestItemsGathered;

    string _message;
    //Material _questIconColor;
    //[SerializeField] Transform _foodTrayPlacement;
    

//BUILT-IN FUNCTIONS
    void Start()
    {
        _uiHud = FindObjectOfType<UI_HUDManager>();
        _questScript = GetComponent<Origin_Quest>();
        _audioManager = FindObjectOfType<Audio_Manager>();

        _renderer = _questStatusIcon.GetComponentInChildren<MeshRenderer>();

        SetIconInitialColor();
    }
      
    void SetIconInitialColor()
    {       
        _renderer.material = _iconColor1;
    }

    void SetIconSecondaryColor()
    {
        _renderer.material = _iconColor2;
    }


    void Update()
    {        
        var _message = "";

        if (_questRelated)
        {
            _questStatusIcon.SetActive(true);

            if (_inZone)
            {
                //??HAS QUEST BEEN COMPLETED??
                if (_questCompleted == false)
                {
                    //USER INPUT
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        //??HAS QUEST BEEN ACCEPTED??
                        if (_questAccepted == false)
                        {
                            //??HAS QUEST BEEN EXPLAINED??
                            if (_questExplained == false)             //if within talking distance and player interacts and no explanation                            
                            {
                                ExplainQuestToPlayer(); Debug.Log("Quest Explained");
                            }

                            else if (_questExplained)                //now the offer is accepted                            
                            {
                                PlayerAcceptsQuest(); Debug.Log("Player Accepts Quest");
                            }
                        }
                        else if (_questAccepted)                        
                            CheckToSeeIfQuestObjectsAccumulated();                        
                        
                        else if (_questCompleted)
                        {
                            if (_hasDisplayedConclusion == false)
                            {
                                _hasDisplayedConclusion = true;
                                _questRelated = false;

                                _dialogDisplay.text = _questScript.RetrieveQuestCompleteDialog;

                                StartCoroutine(DialogTimer());
                                //CompleteArrangementWithPlayer();
                            }
                        }
                    }
                }

            }
        }
        else if (_questRelated == false)                                 //no quest focused banter here, folks!
        {
            _questStatusIcon.SetActive(false);

            if (_inZone && Input.GetKeyDown(KeyCode.E))
            {
                //run the next in a series of secondary dialog outcomes
                ChooseAndRunSecondaryDialog();

                Debug.Log(_message);
            }
        }
    }

    //CORE FUNCTIONS
    void ExplainQuestToPlayer()
    {
        _questExplained = true;

        string requestItems = "";
        foreach (var item in _todoList)
            requestItems += item.ToString();
        _message = _questScript.RetrieveExplainedDialog + " " + requestItems;

        DisplayCurrentQuestState(_message);
        StartCoroutine(DialogTimer());
    }

    void PlayerAcceptsQuest()
    {
        _questAccepted = true;
        
        //_questIconColor = _questStatusIcon.GetComponent<MeshRenderer>().material.color;
        //questIconColor = Color.green;

        _message = _questScript.RetrieveQuestAcceptedDialog;
        DisplayCurrentQuestState(_message);
        StartCoroutine(DialogTimer());

        SetIconSecondaryColor();
        
        _audioManager.PlayGeneralTrack(3);
        Debug.Log(_message);        
    }
    
    void CheckToSeeIfQuestObjectsAccumulated()
    {
        _numberOfQuestItemsGathered = 0;

        _todoList = _questScript.RetrieveTodoList;
        List<GameObject> inventory_player = _playerInventory;

        foreach(var questItem in _todoList)
        {
            foreach(var inventoryItem in inventory_player)
            { 
                if (questItem == inventoryItem)
                    _numberOfQuestItemsGathered++;
            }
        }

        if (_numberOfQuestItemsGathered == _todoList.Count)
        { 
            foreach (var questItem in _todoList)
            {
                if (_playerInventory.Remove(questItem))
                { Debug.Log("Removing: " + questItem + " from Player Inventory"); }

            } 
            CompleteArrangementWithPlayer();
        }
            /*foreach(var inventoryItem in inventory_player)
            //{
                //Debug.Log("Looking Through Inventory");
                //var itemToRemove = inventoryItem.GetComponent<Collectable_Inventory>();
                
                if (questItem == inventoryItem)                                               
                {
                    _numberOfQuestItemsGathered++;
                    Debug.Log("Inventory Item Found");
                    if (inventory_player.Remove(inventoryItem))
                    {
                        Debug.Log("Removed From Inventory: " + inventoryItem);
                    }
                    //_tempList.Add(inventoryItem);
                    Debug.Log("List Capacity" + inventory_player.Capacity);
                    Debug.Log("List Count" + inventory_player.Count);
                    inventory_player.TrimExcess();
                    Debug.Log("List Cap 2" + inventory_player.Capacity);
                }
        }
            

        if (_numberOfQuestItemsGathered >= _todoList.Count)
        {
            Debug.Log("All Quest Items Acquired");
            _questCompleted = true;
                    
            RemoveQuestItemsFromInventory();

            //return;
        }
                //break; 
        }

        Debug.Log("Number Of Quest Items Collected: " + _numberOfQuestItemsGathered);
        Debug.Log("Checking For Quest Items");
        */
    }
    
    void CompleteArrangementWithPlayer()
    {
        //Add Quest Reward To Player Inventory
        var objectForPlayerInventory = _questScript.RetrieveQuestRewardObject;
        //objectForPlayerInventory.transform.position = _foodTrayPlacement.gameObject.transform.position;
        _playerInventory.Add(objectForPlayerInventory);
        
        Debug.Log($"Adding {objectForPlayerInventory} to inventory");
        
        //Play Audio Track
        _audioManager.PlayGeneralTrack(2);

        _questCompleted = true;
        _questRelated = false;

        Debug.Log("This Concludes Our Business");
        //Remove Items From Player Inventory
    }

    
    
    void ChooseAndRunSecondaryDialog()
    {
        _secondaryDialogID++;
        
        if (_secondaryDialogID > _secondaryDialogOptions.Length - 1)
            _secondaryDialogID = 0;

        _message = _secondaryDialogOptions[_secondaryDialogID];
        DisplayCurrentQuestState(_message);

        _audioManager.PlayGeneralTrack(3);
    }



    void DisplayCurrentQuestState(string message)
    {
        _dialogDisplay.text = message;
        StartCoroutine(DialogTimer());
    }


//COROUTINES
    IEnumerator DialogTimer()
    {
        yield return new WaitForSeconds(3.0f);
        _dialogDisplay.text = "";
    }


//TRIGGER FUNCTIONS
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _inZone = true;
            _dialogInstructions.SetActive(true);
            Debug.Log("Press 'E' To Interact");
            _uiHud.DisplayInteractMessage(true);
            _playerInventory = other.GetComponent<Player_Inventory>()._items;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _uiHud.DisplayInteractMessage(false);
            _dialogInstructions.SetActive(false);
            _inZone = false;
        }
    }

}
