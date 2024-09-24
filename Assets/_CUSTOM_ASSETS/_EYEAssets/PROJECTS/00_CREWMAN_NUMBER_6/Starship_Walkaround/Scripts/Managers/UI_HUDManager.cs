using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_HUDManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerMessage;
    [SerializeField] private TMP_Text _stardateDisplay;
    [SerializeField] private TMP_Text _playerModeDisplay;

    [SerializeField] private GameObject _interactMessage;

    
    public void UpdatePlayerMessage(string message)
    {
        _playerMessage.text = message;
        StartCoroutine(PlayerMessageTimer());
    }

    public void PlayerMessagePersist(string message)
    {
        _playerMessage.text = message;
    }

    public void UpdatePlayerMode(string mode)
    {
        _playerModeDisplay.text = mode;
    }

    public void UpdateStardate(string message)
    {
        _stardateDisplay.text = message;        
    }

    public void DisplayInteractMessage(bool value)
    {
        _interactMessage.SetActive(value);
    }

    IEnumerator PlayerMessageTimer()
    {
        yield return new WaitForSeconds(3.0f);
        _playerMessage.text = "";
    }
}
