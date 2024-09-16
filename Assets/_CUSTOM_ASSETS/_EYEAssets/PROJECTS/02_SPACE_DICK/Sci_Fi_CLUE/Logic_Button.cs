using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic_Button : MonoBehaviour
{
    [SerializeField] private GameObject[] _buttonStates;
    int _buttonID;


    void Start()
    {
        ShowCurrentButtonState();
    }

    public void SelectNextButtonState() 
    {
        _buttonID++;
        
        if(_buttonID > _buttonStates.Length-1)
            _buttonID = 0;

        ShowCurrentButtonState();
    }

    void ShowCurrentButtonState()
    {
        foreach (var button in _buttonStates)
            button.SetActive(false);

        _buttonStates[_buttonID].SetActive(true);        
    }
}
