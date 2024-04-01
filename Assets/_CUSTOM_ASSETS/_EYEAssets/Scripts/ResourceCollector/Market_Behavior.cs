using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market_Behavior : MonoBehaviour
{
    [SerializeField] int _numberOfGoods;
    [SerializeField] int _maxNumberOfGoods = 100;
    float _goods_Buy_Cost;
    float _goods_Sell_Cost;
    float _goods_Regular_Cost = 100;
    [SerializeField] int _cargoFree;

    ResourceMarket_UI _uiManager;

    [SerializeField] bool _canAdjust;


    void Start()
    {
        _uiManager = FindObjectOfType<ResourceMarket_UI>();
        _canAdjust= true;

        UpdateCargoUI();
        UpdateCostText();
    }


    void Update()
    {
        CargoCheck();
        Information();
        
        if (_canAdjust)
        {
            _canAdjust = false;

            UpdateCargoUI();
            UpdateCostText();

            StartCoroutine(MarketTimer());
        }
    }

    void CargoCheck()
    {
        if(_numberOfGoods <= 0)
            _numberOfGoods = 0;
        if(_numberOfGoods >= _maxNumberOfGoods)
            _numberOfGoods = _maxNumberOfGoods;
    }

    void Information()
    {
        _cargoFree = _maxNumberOfGoods - _numberOfGoods;

        _goods_Sell_Cost = _cargoFree * 1.0f * _goods_Regular_Cost;
        _goods_Buy_Cost = _cargoFree * 0.9f * _goods_Regular_Cost;
    }

    private void UpdateCargoUI()
    {
        _uiManager.UpdateCargo(_numberOfGoods, _maxNumberOfGoods);
    }

    private void UpdateCostText()
    {
        _uiManager.UpdateCostTexts(_goods_Buy_Cost, _goods_Sell_Cost);
    }

    IEnumerator MarketTimer()
    {
        yield return new WaitForSeconds(1);
        _canAdjust= true;
    }
}
