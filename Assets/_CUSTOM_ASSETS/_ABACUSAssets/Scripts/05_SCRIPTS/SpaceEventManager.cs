using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Collections;

public class SpaceEventManager : MonoBehaviour
{
    [System.Serializable]
    public class WeightedEvent
    {
        public string eventName;
        public float weight;
        public string dialog;
    }

    public List<WeightedEvent> events;
    public SpaceDialogManager dialogManager; // Reference to the UI Text element
    
    void Start()
    {
        var randomEventResult = ChooseRandomEvent();
        var startLine = "You leave the planet toward the Space Market when suddenly...";
        var endLine = "You approach the Space Market.";

        string[] lines = new string[] { startLine, randomEventResult, endLine };
        dialogManager.StartDialog(lines);
    }

    string ChooseRandomEvent()
    {
        string dialog = string.Empty;
        float totalWeight = 0f;
        foreach (var evt in events)
        {
            totalWeight += evt.weight;
        }

        float randomWeight = Random.Range(0f, totalWeight);

        foreach (var evt in events)
        {
            if (randomWeight < evt.weight)
            {
                dialog = evt.dialog;
                break;
            }
            else
            {
                randomWeight -= evt.weight;
            }
        }
        return dialog;
    }
}