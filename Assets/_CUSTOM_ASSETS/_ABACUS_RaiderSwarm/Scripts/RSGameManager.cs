using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RSGameManager : MonoBehaviour
{
    public static RSGameManager Instance;
    public int score = 0;
    public int totalObjectives = 10; // Set this to the total number of objectives in your game
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI objectivesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI victoryText;

    private int completedObjectives = 0;
    private ReturnToMainMenu _menu;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("RSGameManager.Awake():: >multiple gamemagers detected");
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        _menu = GetComponent<ReturnToMainMenu>();
        UpdateUI();
        gameOverText.gameObject.SetActive(false);
        victoryText.gameObject.SetActive(false);
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    public void ObjectiveCompleted()
    {
        completedObjectives++;
        if (completedObjectives == totalObjectives)
        {
            victoryText.gameObject.SetActive(true);
            _menu.ReturnToOriginalMenu();
        }
        UpdateUI();
    }

    void UpdateUI()
    {
        string formattedScore = FormatScoreforUI();
        scoreText.text = formattedScore;
        string remainingFormatted, totalFormatted;
        FormatObjectiveForUI(out remainingFormatted, out totalFormatted);
        objectivesText.text = $"{remainingFormatted}/{totalFormatted}";
    }

    private void FormatObjectiveForUI(out string remainingFormatted, out string totalFormatted)
    {
        remainingFormatted = completedObjectives.ToString("D2");
        totalFormatted = totalObjectives.ToString("D2");
    }

    private string FormatScoreforUI()
    {
        return score.ToString("D8");
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        _menu.ReturnToOriginalMenu();
    }
}
