using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpaceJauntAlpha_UI_Manager : MonoBehaviour
{
    [SerializeField] GameObject[] _uiPanels;

    [SerializeField] float _titleDelay = 4.0f;

    [SerializeField] TMP_Text _playerMessage;
    [SerializeField] TMP_Text _scoreDisplay;
    [SerializeField] TMP_Text _speedDisplay;




//BUILT-IN FUNCTIONS
    void Start()
    {
        UIStartupSequence();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


//DISPLAY PANEL FUNCTIONS
    void UIStartupSequence()
    {
        StartCoroutine(StartUpSequenceTimer());

        foreach (GameObject panel in _uiPanels)
            panel.SetActive(false);
        _uiPanels[0].SetActive(true);

    }

    void DisplayGameplayUI()
    {
        _uiPanels[0].SetActive(false);
        _uiPanels[1].SetActive(true);
        _uiPanels[2].SetActive(true);
    }


//DISPLAY INFORMATION FUNCTIONS
    public void DisplayPlayerMessage(string messageIn)
    {
        StartCoroutine(PlayerDisplayTimer());
    }

    public void DisplaySpeed(float velocityIn)
    {
        _speedDisplay.text = $"SPEED\n{velocityIn.ToString("F2")}";
    }

    public void DisplayScore(int scoreIn)
    {
        _scoreDisplay.text = $"SCORE\n{scoreIn.ToString()}";

    }





//COROUTINES
    IEnumerator StartUpSequenceTimer()
    {
        yield return new WaitForSeconds(_titleDelay);
        DisplayGameplayUI();
    }

    IEnumerator PlayerDisplayTimer()
    {
        yield return new WaitForSeconds(3.0f);
        DisplayPlayerMessage("");
    }


}
