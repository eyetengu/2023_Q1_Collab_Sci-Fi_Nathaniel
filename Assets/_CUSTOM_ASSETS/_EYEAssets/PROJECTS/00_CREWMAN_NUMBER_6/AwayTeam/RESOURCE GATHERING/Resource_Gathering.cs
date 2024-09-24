using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Gathering : MonoBehaviour
{
    UI_GenEx _uiGenEx;
    GeneralExchange_GENEX _genEx;

    //[SerializeField] string _toolName;
    //[SerializeField] string _mineableName;
    [SerializeField] int _harvestAmount = 5;

    [SerializeField] bool _canHarvest = true;
    [SerializeField] float _harvestCooldown = 4.0f;

    [SerializeField] int _crystal, _food, _fuel, _lumber, _ore, _water;

    private void Start()
    {
        _genEx = FindObjectOfType<GeneralExchange_GENEX>();
        _uiGenEx = FindObjectOfType<UI_GenEx>();
    }


    //TRIGGER FUNCTIONS
    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<ResourceToBeGathered>() != null)
        {
            _harvestAmount = other.GetComponent<ResourceToBeGathered>()._harvestAmount;
            _harvestCooldown = other.GetComponent<ResourceToBeGathered>()._harvestTime;
        }

        if (_canHarvest)
        {
            _canHarvest = false;

            if (other.tag == "Crystal")         { _crystal  += _harvestAmount;  _uiGenEx.DisplayCrystals(_crystal); _genEx.AddItemToInventory("Crystal"); }
            else if (other.tag == "Food")       { _food     += _harvestAmount; _uiGenEx.DisplayFood(_food); _genEx.AddItemToInventory("Food"); }
            else if (other.tag == "Gas")        { _fuel     += _harvestAmount; _uiGenEx.DisplayFuel(_fuel); _genEx.AddItemToInventory("Fuel"); }
            else if (other.tag == "Lumber")     { _lumber   += _harvestAmount; _uiGenEx.DisplayLumber(_lumber); _genEx.AddItemToInventory("Lumber"); }
            else if (other.tag == "Ore")        { _ore      += _harvestAmount; _uiGenEx.DisplayOre(_ore); _genEx.AddItemToInventory("Ore"); }
            else if (other.tag == "Water")      { _water    += _harvestAmount; _uiGenEx.DisplayWater(_water); _genEx.AddItemToInventory("Water"); }

            StartCoroutine(MiningDelay());
        }
    }


//COROUTINES
    IEnumerator MiningDelay()
    {
        yield return new WaitForSeconds(_harvestCooldown);
        _canHarvest = true;
    }
}
