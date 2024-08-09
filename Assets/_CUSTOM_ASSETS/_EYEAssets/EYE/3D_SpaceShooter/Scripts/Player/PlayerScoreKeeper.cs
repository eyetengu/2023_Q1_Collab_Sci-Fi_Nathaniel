using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreKeeper : MonoBehaviour
{
    UIManager _uiManager;

    public int Score { get; set; }


    private void Start()
    {
        _uiManager = GameObject.FindObjectOfType<UIManager>();
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
