using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager_Basic : MonoBehaviour
{
    [SerializeField] GameObject _startScreen;
    [SerializeField] GameObject _instructionPanel;

    [SerializeField] GameObject _persistentPanel;
    [SerializeField] GameObject _hudLayers;
    
    void Start()
    {
        SetInitialUIState();
        StartCoroutine(TitleScreenTimer());
    }

    void SetInitialUIState()
    {
        _startScreen.SetActive(true);
        _instructionPanel.SetActive(false);

        _persistentPanel.SetActive(false);
        _hudLayers.SetActive(false);
    }

    IEnumerator TitleScreenTimer()
    {
        yield return new WaitForSeconds(1.0f);
        _instructionPanel.SetActive(true);

        yield return new WaitForSeconds(3.0f);
        FinishLoadSequence();
        ShowGamePlayHUD();
    }

    void FinishLoadSequence()
    {
        _startScreen.SetActive(false);
        _instructionPanel.SetActive(false);
    }

    void ShowGamePlayHUD()
    {
        _persistentPanel.SetActive(true);
        _hudLayers.SetActive(true);
    }
}
