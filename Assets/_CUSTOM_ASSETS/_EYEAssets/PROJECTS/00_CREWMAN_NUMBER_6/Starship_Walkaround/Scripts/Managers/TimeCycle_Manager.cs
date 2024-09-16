using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCycle_Manager : MonoBehaviour
{
    /// <summary>
    /// A shift is a 4-hour scheduled time for working at a station
    /// A sleep routine is a 4-hour allotment of time outside of a shift
    /// An entertainment routine is a 4-hour allotment of time outside of a shift
    /// A full space 'day' is 12 hours long.
    /// Being in space we have less of the concept as on Earth.
    /// Instead, by operating in 4-hour increments for fun, work and recharge we gain advantages:
    /// -maintaining a steady stream of workers, resters and entertained personnel
    /// 
    /// What is a stardate?
    /// What does the number stand for and does it have an origin in time?
    /// Is arrived upon by taking all of the known galaxies, thus far,
    /// comparing and cataloging those times and beginning a new system of date keeping based upon
    /// that information?
    /// 
    /// would it be a four digit code for the year of each of the species plus one to three digits for the space days?
    /// for example: if species a is in year 2024, species b in year 17892 and c in 332 an example might be:
    /// 2024.1789.0332.12
    /// the final digits would signify the star date AFTER the joining of forces and effort.?
    /// 
    /// CONCLUSION
    /// After a long and grueling debat it has been decided that the stardate will maintain the following format:
    /// The day of the period of time after this method has been adopted.
    /// followed by the hour of the 12 hour space day.
    /// Finally, the integer value of the specified time cycle(segment(work, play, rest))
    /// </summary>

    public delegate void UpdateTimeCycle(int cycleID);
    public static event UpdateTimeCycle updatecycle;

    public delegate void StarDateUpdate(int starDateID);
    public static event StarDateUpdate starDateUpdate;

    public delegate void RandomizedEvent();
    public static event RandomizedEvent randomizedEvent;

    public delegate void SpaceLung();
    public static event SpaceLung spaceLung;

    public delegate void ZubInfestation();
    public static event ZubInfestation infestation;

    public delegate void BaseDefense();
    public static event BaseDefense baseDefense;

    [SerializeField] UI_HUDManager _uiHudManager;
    
    [SerializeField] int _hour;
    [SerializeField] int _timeCycleID;
    [SerializeField] int _starDate;
    
    [SerializeField] float _hourLength;
    
    string _mode;
    //[SerializeField] float _lengthOfDay;

    [SerializeField] private GameObject _eventImage;
    [SerializeField] private TMP_Text _eventText;
    string _typeOfEvent;



//BUILT-IN FUNCTIONS
    void Start()
    {
        _uiHudManager = FindObjectOfType<UI_HUDManager>();
        
        if (_uiHudManager != null)
            _uiHudManager.UpdateStardate(_starDate.ToString() + "." + _hour.ToString() + "." + _timeCycleID.ToString());
        
        StartCoroutine(HourLongTimer());
    }

    void Update()
    {
        //TimeCycle_FSM();
        if(Input.GetKeyDown(KeyCode.Z))
        {
            SendRandomEvent();
        }
    }


//COROUTINE
    IEnumerator HourLongTimer()
    {
        yield return new WaitForSeconds(_hourLength);
        AdvanceTheHour();
    }

    void AdvanceTheHour()
    {
        _hour++;
        if (_hour > 12)
            _hour = 1;

        TimeCycle_FSM();
        StartCoroutine(HourLongTimer());
    }


//CORE FUNCTIONS
    void TimeCycle_FSM()
    {
        switch(_hour) 
        {
            case 1:
                AdvanceStarDate();
                AdvanceTimeCycle();
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;

            case 5:
                AdvanceTimeCycle();
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;

            case 9:
                AdvanceTimeCycle();                
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;

            default:
                break;
                     
        }

        DisplayCompleteStardate();
    }

    void AdvanceTimeCycle()
    {
        _timeCycleID++;

        if (_timeCycleID >= 4)
            _timeCycleID = 1;

        if(updatecycle != null)
            updatecycle(_timeCycleID);

        switch (_timeCycleID)
        {
            case 1:
                _mode = "WORK";
                break;
            case 2:
                _mode = "SLEEP";
                break;
            case 3:
                _mode = "ENGAGE";
                break;

            default:
                break;
        }
    }

    void AdvanceStarDate()
    {
        _starDate++;

        if (starDateUpdate != null)
            starDateUpdate(_starDate);

        if (_starDate % 10 == 0)
            SendRandomEvent();

    }

    void DisplayCompleteStardate()
    {
        if (_uiHudManager != null)
        {
            _uiHudManager.UpdateStardate($"{_starDate.ToString()}:{_hour}:{_timeCycleID}");
            _uiHudManager.UpdatePlayerMode($"{_mode}");
        }
    }


    void SendRandomEvent()
    {
        StartCoroutine(EventDisplayTimer());

        _eventImage.SetActive(true);

        var eventID = Random.Range(0, 3);
        {
            switch (eventID)
            {
                case 0:
                    Debug.Log("SpaceLung");
                    _typeOfEvent = "SpaceLung";
                    if (spaceLung != null)
                        spaceLung();
                    break;
                case 1:
                    Debug.Log("Infestation");
                    _typeOfEvent = "Infestation";
                    if (infestation != null)
                        infestation();
                    break;
                case 2:
                    Debug.Log("Base Defense");
                    _typeOfEvent = "Base Defense";
                    if (baseDefense != null)
                        baseDefense();
                    break;
            }
        }
        _eventText.text = _typeOfEvent;
    }

    IEnumerator EventDisplayTimer()
    {
        yield return new WaitForSeconds(30);
        _eventImage.SetActive(false);
        _eventText.text = "";
    }





}
