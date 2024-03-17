using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starship_Event_Core : MonoBehaviour
{
    //Delegates
    public delegate void Work();
    public delegate void Play();
    public delegate void Rest();

    //Events
    public static event Work work;
    public static event Play play;
    public static event Rest rest;

    public delegate void NewDay();

    public static event NewDay newDay;

    private bool _isDay;                                    //day and night will have individual needs when it comes to lighting
    [SerializeField] private float _hourDurationSec = 1;                                //the hour is measured in seconds(float)
    private float _lengthOfDay;
    [SerializeField] private float _universeSpeed = 2;      //the speed of the rotation of the sun/moon
    private int _hourID;                                    //the integer form of the time(hour)
    private string _stateString;                            //when a state has a name it is stored here
    [SerializeField] private UI_Manager _uiManager;         //the ui manager reference to display data
    private int _dayYear;                                   //the max days of the year: 364(zero-indexed)
    private int _dayMonth;                                  //max: 6(zero-indexed)
    private int _month;
    private int _year;                                      //which year is it

    [SerializeField] private CinemachineVirtualCamera _makeMeLaughCam;
    private bool _isCursorLocked;


    private void Start()
    {
        _lengthOfDay = _hourDurationSec * 24;

        FiniteStateMachine_DayCycle();
        LockCursorInvisible();
    }

    private void Update()
    {
       
    }

    //CURSOR
    void LockCursorInvisible()
    {
        //_isCursorLocked= true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void UnlockCursorVisible()
    {
        //_isCursorLocked= false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //Progress through the day
    void NextHour()             //Progress through the day
    {
        _hourID++;

        if (_hourID >= 12)          //Increase Day Integer
        {
            _hourID = 0;
            _dayMonth++;
            //newDay();
            _dayYear++;

            if (_dayMonth > 29)     //Increase Month integer
            {
                _dayMonth = 0;
                _month++;

                if (_month > 11)      //Increase Year integer
                {
                    _month = 0;
                    _year++;
                }
            }
            //Debug.Log("State: " + _dayStateID);
        }

        FiniteStateMachine_DayCycle();
        //Debug.Log(_month.ToString() + "/" + _dayYear.ToString() + "/" + _year.ToString());     
    }

    //FSM
    void FiniteStateMachine_DayCycle()
    {
        switch (_hourID)
        {
            case 0:
                _stateString = "Work";
                //work();
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                _stateString = "Play";
                //play();
                break;
            case 5:
                break;
            case 6:                
                break;
            case 7:
                break;
            case 8:
                _stateString = "Rest";
                //rest();
                break;
            case 9:
                break; 
            case 10:
                break;
            case 11:    
                break;            

            default: break;
        }

        UpdateUI();
        StartCoroutine(HourLength());

    }

    void UpdateUI()
    {
        var dayOfYear = _dayYear + 1;
        if(_uiManager!= null)
            _uiManager.UpdateUIMessage(_stateString, _hourID, dayOfYear);
    }


    //COROUTINES
    IEnumerator HourLength()
    {
        yield return new WaitForSeconds(_hourDurationSec);
        NextHour();
    }
}
