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

    [SerializeField] TMP_Text _pitchValue;
    [SerializeField] TMP_Text _rollValue;
    [SerializeField] TMP_Text _yawValue;


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

    public void DisplaySpeed(int velocityIn)
    {
        _speedDisplay.text = $"SPEED\n{velocityIn.ToString("F0")}";
    }

    public void DisplayScore(int scoreIn)
    {
        _scoreDisplay.text = $"SCORE\n{scoreIn.ToString()}";

    }


//PRY VALUES
    public void DisplayPitch(float pitchIn)
    {
        _pitchValue.text = pitchIn.ToString();
    }

    public void DisplayRoll(float rollIn)
    {
        _rollValue.text = rollIn.ToString("F0");
    }

    public void DisplayYaw(float yawIn)
    {
        _yawValue.text = yawIn.ToString("F0");
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
