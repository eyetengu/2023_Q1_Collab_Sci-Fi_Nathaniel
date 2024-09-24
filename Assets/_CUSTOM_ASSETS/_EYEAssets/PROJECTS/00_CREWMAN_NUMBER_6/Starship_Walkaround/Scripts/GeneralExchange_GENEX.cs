using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralExchange_GENEX : MonoBehaviour
{        
    //UI_Manager_StarshipWalkAround _uiManager;
    UI_GenEx _uiManager;

    int _experience;
    int _gold;
    int _health;
    int _score;

    int _food;
    int _fuel;
    int _lumber;
    int _mineral;
    int _ore;
    int _water;

    List<GameObject> _listOfItems = new List<GameObject>();
    List<string> _listOfItemNames = new List<string>();

//PROPERTIES
    public int Experience { get; set; }
    public int Gold     { get; set; }
    public int Health   { get; set; }
    public int Score    { get; set; }    
    

//BUILT-IN FUNCTIONS
    void Start()
    {
        //_uiManager = FindObjectOfType<UI_Manager_StarshipWalkAround>();
        _uiManager = FindObjectOfType<UI_GenEx>();

        DisplayAllValues();
    }

    void Update()
    {
        
    }

    void DisplayAllValues()
    {
        if (_uiManager != null)
        {
            _uiManager.DisplayScore(Score);
            _uiManager.DisplayExperience(Experience);
            _uiManager.DisplayGold(Gold);
            _uiManager.DisplayHealth(Health);
        }
    }





//VALUES LEVEL ONE
    public void AdjustExperience(int adjustmentValue) 
    {
        Debug.Log("Adjusting Experiency by : " + adjustmentValue);
        Experience += adjustmentValue;
        if(_uiManager != null)
            _uiManager.DisplayExperience(Experience);
    }
    public void AdjustGold(int adjustmentValue)  
    {  
        Gold += adjustmentValue;
        if (_uiManager != null) 
            _uiManager.DisplayGold(Gold);
    }
    public void DisplayHealth(int healthIn)
    {
        Health += healthIn;
        if (_uiManager != null) 
            _uiManager.DisplayHealth(Health);
    }
    public void AdjustScore(int adjustmentValue) 
    {  
        Score += adjustmentValue;
        if (_uiManager != null) 
            _uiManager.DisplayScore(Score);
    }

    
//VALUES LEVEL TWO
    public void HarvestFood(int foodIn) { _food += foodIn; }
    public void HarvestFuel(int fuelIn) { _fuel += fuelIn; }
    public void HarvestLumber(int lumberIn) { _lumber += lumberIn; }
    public void HarvestMineral(int mineralIn) { _mineral += mineralIn; }
    public void HarvestOre(int oreIn) { _ore += oreIn; }
    public void HarvestWater(int waterIn) { _water += waterIn; }







//ADJUSTING INVENTORY
    public void AddItemToInventory(GameObject objectToAdd) 
    { 
        _listOfItems.Add(objectToAdd);
        if (_uiManager != null)
            _uiManager.ShowInventoryItems(_listOfItems);
    }

    public void AddItemToInventory(string objectToAdd)
    {
        _listOfItemNames.Add(objectToAdd);
        //_uiManager.ShowInventoryItems(_listofItemNames);
    }

    void RemoveItemFromInventory(GameObject objectToRemove) 
    { 
        _listOfItems.Remove(objectToRemove);
        if (_uiManager != null)
            _uiManager.ShowInventoryItems(_listOfItems);
    }
}
