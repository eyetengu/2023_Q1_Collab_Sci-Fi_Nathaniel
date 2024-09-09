using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameDisplaySample : MonoBehaviour
{
    [SerializeField] private AbacusGameManager gameManager;
    private TextMeshProUGUI displayName;
    // Start is called before the first frame update
    void Start()
    {
        displayName = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        displayName.text = gameManager.PlayerName;

    }
}
