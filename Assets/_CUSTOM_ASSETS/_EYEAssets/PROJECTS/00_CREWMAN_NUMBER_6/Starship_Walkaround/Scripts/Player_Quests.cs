using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Quests : MonoBehaviour
{
    [SerializeField] List<string> _activeQuests;


    
    void AddActiveQuest(string questToAdd)
    {
        _activeQuests.Add(questToAdd);
    }

    void RemoveInactiveQuest(string questToRemove)
    {
        _activeQuests.Remove(questToRemove);
    }
}
