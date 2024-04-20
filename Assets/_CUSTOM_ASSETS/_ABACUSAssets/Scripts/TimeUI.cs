using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class TimeUI : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject displayTextObject;

    void Update()
    {
        if (levelManager == null)
        {
            Debug.LogError("TimeUI>> level manager not assigned");
            return;
        }

        if (displayTextObject == null)
        {
            Debug.LogError("TimeUI>> displayTextObject not assigned");
            return;
        }

        float remainingTime = levelManager.RemainingMissionTime;
        float displayMinute = Mathf.Floor(remainingTime / 60f);
        float displaySeconds = Mathf.Floor(remainingTime % 60f);

        displayTextObject.GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", displayMinute, displaySeconds);
    }
}
