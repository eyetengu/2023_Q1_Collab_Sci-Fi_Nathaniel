using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    GeneralExchange_GENEX _genEx;



    void Start()
    {
        _genEx = FindObjectOfType<GeneralExchange_GENEX>();
    }


    void Update()
    {
        
    }

    public void PassItemToInventory(GameObject objectToAdd)
    {
        _genEx.AddItemToInventory(objectToAdd);
    }




}
