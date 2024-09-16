using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_GenEx : MonoBehaviour
{
    [Header("GENEX VALUES")]
    [SerializeField] TMP_Text _experienceValue;
    [SerializeField] TMP_Text _goldValue;
    [SerializeField] TMP_Text _healthValue;
    [SerializeField] TMP_Text _scoreValue;

    [SerializeField] TMP_Text _inventoryList;

    [SerializeField] TMP_Text _crystalValue;
    [SerializeField] TMP_Text _foodValue;
    [SerializeField] TMP_Text _fuelValue;
    [SerializeField] TMP_Text _lumberValue;
    [SerializeField] TMP_Text _oreValue;
    [SerializeField] TMP_Text _waterValue;


    //Display Values
    public void DisplayScore(int score)
    {
        _scoreValue.text = score.ToString();
    }

    public void DisplayExperience(int experience)
    {
        _experienceValue.text = experience.ToString();
    }

    public void DisplayGold(int gold)
    {
        _goldValue.text = gold.ToString();
    }

    public void DisplayHealth(int health)
    {
        _healthValue.text = health.ToString();
    }

    public void ShowInventoryItems(List<GameObject> items)
    {
        _inventoryList.text = "";
        foreach (var item in items)
            _inventoryList.text += item.name + "\n";
    }

    
    public void DisplayCrystals(int crystalsIn) { _crystalValue.text = crystalsIn.ToString();   }
    public void DisplayFood(int foodIn)         { _foodValue.text = foodIn.ToString();          }
    public void DisplayFuel(int fuelIn)         { _fuelValue.text = fuelIn.ToString();          }
    public void DisplayLumber(int lumberIn)     { _lumberValue.text = lumberIn.ToString();      }
    public void DisplayOre(int oreIn)           { _oreValue.text = oreIn.ToString();            }
    public void DisplayWater(int waterIn)       { _waterValue.text = waterIn.ToString();        }
}
