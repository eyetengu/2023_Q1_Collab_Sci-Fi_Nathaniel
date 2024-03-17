using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _introPanel;


    public void UpdateUIMessage(string message, int state, int dayOfYear)
    {
        if (state < 10)
            _text.text = "Day: " + dayOfYear + "\nTime: 0" + state + ":00\nState: " + message;
        else
            _text.text = "Day: " + dayOfYear + "\nTime: " + state + ":00\nState: " + message;
    }

    public void TurnOffIntroPanel()
    {
        _introPanel.SetActive(false);
    }
}
