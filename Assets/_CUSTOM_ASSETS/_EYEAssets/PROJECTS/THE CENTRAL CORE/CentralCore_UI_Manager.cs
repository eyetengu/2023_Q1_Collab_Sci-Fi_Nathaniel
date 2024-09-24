using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CentralCore_UI_Manager : MonoBehaviour
{
    [Header("UI PANELS")]
    [SerializeField] GameObject _titleScreen;
    [SerializeField] GameObject _mainMenuScreen;


//BUILT-IN FUNCTIONS
    void Start()
    {
        InitiateUIStartScreenSequence();
    }


//CORE FUNCTIONS
    void InitiateUIStartScreenSequence()
    {
        StartCoroutine(TitleScreenDuration());
        _mainMenuScreen.SetActive(false);
        _titleScreen.SetActive(true);
    }


//COROUTINES
    IEnumerator TitleScreenDuration()
    {
        yield return new WaitForSeconds(4.0f);
        _titleScreen.SetActive(false);
        _mainMenuScreen.SetActive(true);
    }
}
