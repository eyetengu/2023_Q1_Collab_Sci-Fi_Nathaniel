using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Logic_Puzzle_Behavior : MonoBehaviour
{
    [SerializeField] List<LogicCharacter> characterList;


    void Start()
    {
        LogicCharacter _char01 = new LogicCharacter("Bob", "Bridge", "Noodles", "Radar", "Jerky");
        LogicCharacter _char02 = new LogicCharacter("Millie", "Science", "Cocaine", "Gear", "Limbs");
        LogicCharacter _char03 = new LogicCharacter("Samuel", "Loading", "Bits", "Battery", "Burger");
    }


    void Update()
    {
        
    }
}

[System.Serializable]
public class LogicCharacter
{
    string _characterName;
    string _location;
    string _lunchOrder;
    string _miniSign;
    string _jobLocation;

    public LogicCharacter( string name, string location, string lunch, string sign, string job)
    {
        this._characterName = name;
        this._location = location;
        this._lunchOrder = lunch;
        this._miniSign = sign;
        this._jobLocation = job;
    }
}
