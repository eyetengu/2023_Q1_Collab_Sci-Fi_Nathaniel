using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CentralCore_UI_Manager : MonoBehaviour
{
    [Header("UI PANELS")]
    [SerializeField] GameObject _titleScreen;
    [SerializeField] GameObject _mainMenuScreen;


    [SerializeField] TMP_Text _speedDisplay;


//BUILT-IN FUNCTIONS
    void Start()
    {
        InitiateUIStartScreenSequence();
    }

    void Update()
    {
        
    }


//CORE FUNCTIONS
    void InitiateUIStartScreenSequence()
    {
        StartCoroutine(TitleScreenDuration());
        _mainMenuScreen.SetActive(false);
        _titleScreen.SetActive(true);
    }


    void DisplaySpeed(float velocityIn)
    {
        string speed = velocityIn.ToString();
        _speedDisplay.text = $"Speed: {speed}";
    }






//COROUTINES
    IEnumerator TitleScreenDuration()
    {
        yield return new WaitForSeconds(4.0f);
        _titleScreen.SetActive(false);
        _mainMenuScreen.SetActive(true);
    }
}
