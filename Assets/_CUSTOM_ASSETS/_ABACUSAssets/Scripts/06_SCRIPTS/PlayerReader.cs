using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerReader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var displayText = GetComponentInChildren<TextMeshProUGUI>();
        var playerManager = FindFirstObjectByType<MockPlayerManager>();
        if (displayText != null && playerManager != null)
        {
            displayText.text = playerManager.Name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
