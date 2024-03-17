using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_FSM : MonoBehaviour
{
    public enum NPCStates
    {
        Work, Play, Sleep
    }

    public NPCStates _currentNPCState;

    Starship_Event_Core _starshipEventSystem;



    private void Start()
    {
        Starship_Event_Core.work += SetWorkCondition;


        _currentNPCState= new NPCStates();
        _currentNPCState = NPCStates.Work;
    }

    void SetWorkCondition()
    {
        _currentNPCState = NPCStates.Work;
    }

    void SetPlayCondition()
    {
        _currentNPCState = NPCStates.Play;
    }

    void SetRestCondition()
    {
        _currentNPCState = NPCStates.Sleep;
    }

    private void Update()
    {
        FSM_Core();
    }

    void FSM_Core()
    {
        switch(_currentNPCState)
        {
            case NPCStates.Work:
                CloseAllStates();

                break;
            case NPCStates.Play:
                CloseAllStates();

                break; 
            case NPCStates.Sleep:
                CloseAllStates();

                break;
            default:
                break;
        }
    }

    void CloseAllStates()
    {


    }
}
