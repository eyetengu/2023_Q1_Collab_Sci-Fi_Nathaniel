using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    GeneralExchange_GENEX _genEx;

    [SerializeField] public List<GameObject> _items;
    [SerializeField] public List<GameObject> _tools;
    [SerializeField] public List<GameObject> _weapons;


//BUILT-IN FUNCTIONS
    void Start()
    {
        _genEx = FindObjectOfType<GeneralExchange_GENEX>();
    }


//ADD FUNCTIONS
    public void AddItemToInventory(GameObject itemToAdd) 
    { 
        Debug.Log($"Adding {itemToAdd}"); 
        _items.Add(itemToAdd); 
        _genEx.AddItemToInventory(itemToAdd); 
    }
    
    public void AddToolToTools(GameObject toolToAdd) 
    { 
        _tools.Add(toolToAdd); 
    }
    
    public void AddWeaponToWeapons(GameObject WeaponToAdd) 
    { 
        _weapons.Add(WeaponToAdd); 
    }

//REMOVE FUNCTIONS
    public void RemoveItemFromInventory(GameObject itemToRemove) 
    { _items.Remove(itemToRemove); }
    
    public void RemoveToolFromTools(GameObject toolToRemove) 
    { _tools.Remove(toolToRemove); }
    
    public void RemoveWeaponFromWeapons(GameObject weaponToRemove) 
    { _weapons.Remove(weaponToRemove); }





    public void AddQuestToList(string _questName)
    {

    }
    public void RemoveQuestFromList(string questName)
    {

    }
}
