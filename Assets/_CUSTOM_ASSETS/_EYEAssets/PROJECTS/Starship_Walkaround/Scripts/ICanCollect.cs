using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICanCollect : MonoBehaviour
{
    GeneralExchange_GENEX _genEx;


    void Start()
    {
        _genEx = FindObjectOfType<GeneralExchange_GENEX>();
    }


    void Update()
    {
        
    }
    public void PassValueToGenEx(int value , string typeOfCollectable)
    {
        switch(typeOfCollectable)
        {
            case "exp":
                _genEx.AdjustExperience(value);
                break;
            case "gol":
                _genEx.AdjustGold(value);
                break;
            case "hea":
                _genEx.DisplayHealth(value);
                break;
            case "sco":
                _genEx.AdjustScore(value);
                break;
            default:
                break;

        }
        Debug.Log("Passing Value: " + typeOfCollectable + value);
    }



    public void PassItemInfo(int health)
    {
        //_genEx.Health += health;
        _genEx.DisplayHealth(health);
    }
}
