using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Tablet : MonoBehaviour
{
    [SerializeField] GameObject _tabletObject;
    bool _showTablet;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            _showTablet = !_showTablet;

        _tabletObject.SetActive(_showTablet);

    }
}
