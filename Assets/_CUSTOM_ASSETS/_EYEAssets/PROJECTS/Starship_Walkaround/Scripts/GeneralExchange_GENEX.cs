using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class GeneralExchange_GENEX : MonoBehaviour
{        
    UI_Manager_StarshipWalkAround _uiManager;

    int _experience;
    int _gold;
    int _health;
    int _score;

    List<GameObject> _listOfItems = new List<GameObject>();

//PROPERTIES
    public int Experience { get; set; }
    public int Gold     { get; set; }
    public int Health   { get; set; }
    public int Score    { get; set; }    
    

//BUILT-IN FUNCTIONS
    void Start()
    {
        _uiManager = FindObjectOfType<UI_Manager_StarshipWalkAround>();
        DisplayAllValues();
    }

    void Update()
    {
        
    }

    void DisplayAllValues()
    {
        _uiManager.DisplayScore(Score);
        _uiManager.DisplayExperience(Experience);
        _uiManager.DisplayGold(Gold);
        _uiManager.DisplayHealth(Health);
    }





//CORE FUNCTIONS
    public void AdjustExperience(int adjustmentValue) 
    {
        Debug.Log("Adjusting Experiency by : " + adjustmentValue);
        Experience += adjustmentValue;
        _uiManager.DisplayExperience(Experience);
    }
    public void AdjustGold(int adjustmentValue)  
    {  
        Gold += adjustmentValue;
        _uiManager.DisplayGold(Gold);
    }
    public void DisplayHealth(int healthIn)
    {
        Health += healthIn;
        _uiManager.DisplayHealth(Health);
    }
    public void AdjustScore(int adjustmentValue) 
    {  
        Score += adjustmentValue;
        _uiManager.DisplayScore(Score);
    }

    public void AddItemToInventory(GameObject objectToAdd) 
    { 
        _listOfItems.Add(objectToAdd);

        _uiManager.ShowInventoryItems(_listOfItems);
    }
    void RemoveItemFromInventory(GameObject objectToRemove) 
    { 
        _listOfItems.Remove(objectToRemove);

        _uiManager.ShowInventoryItems(_listOfItems);
    }
}
