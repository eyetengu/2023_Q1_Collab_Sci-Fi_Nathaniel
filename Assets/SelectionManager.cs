using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Button buttonRaiderSwarm;
    [SerializeField] private Button buttonConvoyDefender;
    [SerializeField] private Button buttonCredits;

    private void Start()
    {
        buttonRaiderSwarm.onClick.AddListener(() =>
        {
            OnButtonClick(SceneSelection.RaiderSwarm1);
        });
        buttonConvoyDefender.onClick.AddListener(() =>
        {
            OnButtonClick(SceneSelection.ConvoyDefender);
        });
        buttonCredits.onClick.AddListener(() =>
        {
            OnButtonClick(SceneSelection.MainMenuCredits);
        });
    }

    void OnButtonClick(SceneSelection selection)
    {
        int selectionId = (int)selection;
        if (selectionId >= 0 && selectionId < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(selectionId);
        }
        else
        {
            Debug.LogWarning("Invalid scene ID");

        }
    }

        private void OnDestroy()
    {
        buttonRaiderSwarm.onClick.RemoveListener(() =>
        {
            OnButtonClick(SceneSelection.RaiderSwarm1);
        });
        buttonConvoyDefender.onClick.RemoveListener(() =>
        {
            OnButtonClick(SceneSelection.ConvoyDefender);
        });
        buttonCredits.onClick.RemoveListener(() =>
        {
            OnButtonClick(SceneSelection.RaiderSwarm1);
        });

    }
}

public enum SceneSelection
{
    MainMenu = 0,
    ConvoyDefender,
    RaiderSwarm1,
    RaiderSwarm2,
    RaiderSwarm3,
    RaiderSwarmCredits,
    MainMenuCredits
}
