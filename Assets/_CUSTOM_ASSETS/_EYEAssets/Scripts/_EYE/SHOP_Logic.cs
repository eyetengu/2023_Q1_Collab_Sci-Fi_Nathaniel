using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SHOP_Logic : MonoBehaviour
{
    [SerializeField] List<GameObject> _inventoryObjects;
    [SerializeField] List<float> _inventoryPrices;

    [SerializeField] List<GameObject> _inStockInventory = new List<GameObject>();
    List<float> _inStockPricing = new List<float>();

    [SerializeField] TMP_Text _inventoryDisplay;
    [SerializeField] TMP_Text _pricingDisplay;


    void Start()
    {
        PopulateShopInventory();
    }

    void Update()
    {
        
    }

    void PopulateShopInventory()
    {
        for (int i = 0; i < 10; i++)
        {
            var randomID = Random.Range(0, _inventoryObjects.Count - 1);

            _inStockInventory.Add(_inventoryObjects[randomID]);
            _inStockPricing.Add(_inventoryPrices[randomID]);
        }
        DisplayInventoryComplete();
    }

    void DisplayInventoryComplete()
    {
        var message = "";
        var messagePrices = "";
        var itemID = 0;

        foreach(var item in _inStockInventory)
        {
            message += item.name + "\n";
            messagePrices += _inStockPricing[itemID].ToString() + "c\n";
            itemID++;
        }
        _inventoryDisplay.text = message;
        _pricingDisplay.text = messagePrices;
    }
}
