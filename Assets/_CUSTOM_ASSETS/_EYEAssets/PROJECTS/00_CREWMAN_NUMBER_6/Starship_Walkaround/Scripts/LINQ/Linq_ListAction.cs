using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;


public class Linq_ListAction : MonoBehaviour
{
    [SerializeField] List<string> player_Inventory = new List<string>();

    [SerializeField] Linq_List01 neededQuestItems;
    [SerializeField] int counter;
    bool _overlapItems;
    IEnumerable<string> _itemsInOverlap;

    [SerializeField] TMP_Text _questObjects;
    [SerializeField] TMP_Text _playerInventoryWindow;





    void Start()
    {
        Debug.Log(player_Inventory.Count);
        
        var message = "";
        foreach (var item in player_Inventory)
        {
            message += item + "\n";
        }
        _playerInventoryWindow.text = message;

        _questObjects.text = neededQuestItems.itemsNeeded.Count.ToString() + "\n";
        var messageQuest = "";
        foreach (var tem in neededQuestItems.itemsNeeded)
            messageQuest += tem + "\n";

        _questObjects.text += messageQuest;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            RemoveItemsFromPlayerInventory();
    }

    List<string> QuestItemsInfo()
    {
        return neededQuestItems.itemsNeeded;

    }


    void CompareInventoryWithList()
    {
        var itemsInInventory = "";

        //Use Quest list to check against
        foreach (var questItem in neededQuestItems.itemsNeeded)
        {
            //create a list of overlapping items
            _itemsInOverlap = player_Inventory.Where(n => n == questItem);
            foreach(var item in _itemsInOverlap)
            {
                itemsInInventory += item + " ";
            }
        }        
        Debug.Log(itemsInInventory + "\n");
    }

    void RemoveItemsFromPlayerInventory()
    {
        _questObjects.text = neededQuestItems.itemsNeeded.Count.ToString() + "\n";

        var messageQuest = "";
        foreach (var tem in neededQuestItems.itemsNeeded)
            messageQuest += tem + "\n";
        
        _questObjects.text += messageQuest;
        
        foreach (var questItem in neededQuestItems.itemsNeeded)
        {
            //Debug.Log(player_Inventory.Count);
            //create a list of overlapping items
            _itemsInOverlap = player_Inventory.Where(n => n == questItem);
            if(player_Inventory.Remove(questItem))
            {
                Debug.Log($"{questItem} Removed from Player Inventory");
            }
            //Debug.Log(player_Inventory.Count);
        }
        var message = "";
        foreach(var item in player_Inventory)
        {
            message += item + "\n";
        }

        _playerInventoryWindow.text = message;
    }


    void ComparisonCheck()
    {
        var message = "";
        

        foreach (var questItem in neededQuestItems.itemsNeeded)
        {
            foreach (var inventoryItem in player_Inventory)
            {
                if (questItem == inventoryItem)
                {
                    counter++;
                    message += questItem + ", ";
                }
            }
        }
        Debug.Log("Count: " + counter + " " + message);
    }
}
