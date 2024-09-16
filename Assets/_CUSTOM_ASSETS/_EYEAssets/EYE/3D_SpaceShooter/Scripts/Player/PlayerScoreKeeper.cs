using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreKeeper : MonoBehaviour
{
    UIManager _uiManager;

    public int Score { get; set; }

    private void OnEnable()
    {
        Event_Manager.increaseScore += IncreaseScoreByOne;
    }

    private void OnDisable()
    {
        Event_Manager.increaseScore += IncreaseScoreByOne;
    }

    private void Start()
    {
        _uiManager = GameObject.FindObjectOfType<UIManager>();
    }

    void IncreaseScoreByOne()
    {
        Score++;
        ShowUIScore();
    }

    public void UpdateScore(int score)
    {
        Score += score;
        
        ShowUIScore();
    }

    void ShowUIScore()
    {
        _uiManager.DisplayScore(Score);
    }
}
