using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_TimeOfDay : MonoBehaviour
{
    UI_HUDManager _uiManager;
    float _rested;
    float _fullyRested = 100;

    public float Rested { get; set; }

    string _playerMode;    


    private void OnEnable()
    {
        TimeCycle_Manager.updatecycle += NotifyOfWorkPlaySleepSchedule;        
    }

    private void OnDisable()
    {
        TimeCycle_Manager.updatecycle -= NotifyOfWorkPlaySleepSchedule;
    }

    private void Start()
    {
        _uiManager = FindObjectOfType<UI_HUDManager>();
        Rested = _fullyRested;   
    }

    private void NotifyOfWorkPlaySleepSchedule(int cycleID)
    {
        string messageToSelf = "";

        switch (cycleID)
        {
            case 0:messageToSelf = "WORK TIME";
                break;
            case 1:            
                messageToSelf = "PlAY TIME";
                break;
            case 2:            
                messageToSelf = "SLEEP TIME";
                break;
            case 3:            
                messageToSelf = "SOME TIME";
                break;

            default:
                break;
        }
        _uiManager.UpdatePlayerMode(messageToSelf);
    }

    public void IncreaseRestedValue(int restoreValue)
    {
        Rested += restoreValue;
    }

    public void DecreaseRestedValue(int decreaseHealth)
    {
        Rested -= decreaseHealth;
    }

    


}
