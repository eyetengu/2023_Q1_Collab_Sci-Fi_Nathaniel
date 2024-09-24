using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Manager : MonoBehaviour
{
    [SerializeField] List<string> _activeQuests = new List<string>();
    [SerializeField] List<string> _completedQuests = new List<string>();

    Game_Manager _gameManager;
    UI_Manager _uiManager;
    [SerializeField] int _numberOfQuestsToWin;
    bool _gameWon;


//BUILT-IN FUNCTIONS
    private void OnEnable()
    {
        _gameManager = FindObjectOfType<Game_Manager>();
        _uiManager = FindObjectOfType<UI_Manager>();

        //Game_Manager.pauseGame += PauseActivity;
        //Game_Manager.unPauseGame += UnPauseActivity;
    }

    private void Start()
    {
        _uiManager = GameObject.FindObjectOfType<UI_Manager>();
    }

    void Update()
    {
       
        if (_completedQuests.Count >= _numberOfQuestsToWin && _gameWon == false)
        {
            _gameWon = true;
            _gameManager.YouWin();

            var message = $"You have completed all " + _numberOfQuestsToWin + " quests!";
            //_uiManager.UpdateEndGameMessage(message);
        }
    }

    private void OnDisable()
    {
        //Game_Manager.gameWon -= PauseActivity;
        //Game_Manager.unPauseGame -= UnPauseActivity;
    }


//CORE FUNCTIONS
    public void AddActiveQuest(string quest)
    {
        _activeQuests.Add(quest);
    }

    public void AddCompletedQuest(string quest)
    {
        _activeQuests.Remove(quest);
        _completedQuests.Add(quest);
    }

    void PauseActivity()
    {
        //Debug.Log("Quest_ Paused");
    }

    void UnPauseActivity()
    {
        //Debug.Log("Quest_ UnPaused");
    }
}


///quest narrative
///You are crewman number six. No name- first or last.
///If somebodys gotta go this round it might as well be you.
///If its on the ship and can eat you... it probably will.
///If youre down on the planet and you take a gamble you just might wind up aces and eights.
///

///Wouldnt you know it.
///One too many people was assigned to this space craft and it looks like its you.
///Another mouth to feed is going to have an interesting effect on things.
///Good news is that you have a wide range of skills and you enjoy solving problems.
///That, coupled with your desire to maintain relevance(read have room and board) you will  have to put your skills to the test
///

///A space day is only 12 hours long
///it is broken down into three 4 hr shifts that most refer to as work, sleep and play.
///you have a set work schedule
///When and how you sleep and play is up to you.
///

///So many ways to go.
///door malfunction on lavatory. locked for a work shift
///airlock 'accidentally' left open. *wink *wink
///falling panel
///debris pile
///npc on board has a rare, dangerous, stealthy alien pet gotten loose.
///