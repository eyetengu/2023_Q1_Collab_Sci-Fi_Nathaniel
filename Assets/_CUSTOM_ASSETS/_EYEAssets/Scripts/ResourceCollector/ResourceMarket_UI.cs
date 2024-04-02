using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceMarket_UI : MonoBehaviour
{
    [SerializeField] TMP_Text _cargoText;
    [SerializeField] TMP_Text _buyText;
    [SerializeField] TMP_Text _sellText;



    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateCargo(int cargo, int max)
    {
        _cargoText.text = cargo.ToString() + "/" + max.ToString();
    }

    public void UpdateCostTexts(float buy, float sell)
    {
        _buyText.text = "$" + buy.ToString();
        _sellText.text = "$" + sell.ToString();
    }
}
