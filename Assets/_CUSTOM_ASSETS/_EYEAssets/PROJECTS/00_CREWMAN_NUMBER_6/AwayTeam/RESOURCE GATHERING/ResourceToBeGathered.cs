using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceToBeGathered : MonoBehaviour
{
    public enum ResourceType { Ore, Lumber, Mineral, Water, Food, Fuel }
    public ResourceType _currentResource;
    public float _harvestTime;
    public int _harvestAmount;
    
    GeneralExchange_GENEX _resourceGatherer;


//CORE FUNCTIONS
    void Resource_FSM()
    {
        switch (_currentResource)
        {
            case ResourceType.Ore:
                _resourceGatherer.HarvestOre(_harvestAmount);
                break;
            case ResourceType.Lumber:
                _resourceGatherer.HarvestLumber(_harvestAmount);
                break;
            case ResourceType.Mineral:
                _resourceGatherer.HarvestMineral(_harvestAmount);
                break;
            case ResourceType.Water:
                _resourceGatherer.HarvestWater(_harvestAmount);
                break;
            case ResourceType.Food:
                _resourceGatherer.HarvestFood(_harvestAmount);
                break;
            case ResourceType.Fuel:
                _resourceGatherer.HarvestFuel(_harvestAmount);
                break;

            default:
                break;
        }

        Debug.Log("Resource: " + _currentResource);
    }


//COROUTINES
    IEnumerator HarvestResource()
    {
        yield return new WaitForSeconds(_harvestTime);
        Resource_FSM();
    }
}
