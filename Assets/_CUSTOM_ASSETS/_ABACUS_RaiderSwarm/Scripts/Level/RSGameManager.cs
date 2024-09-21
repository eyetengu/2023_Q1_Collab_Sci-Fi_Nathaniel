using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RSGameManager : MonoBehaviour
{
    private const string BIG_BULLET_TEXT = "Big Lazer";
    public static RSGameManager Instance;
    public int totalObjectives = 10; // Set this to the total number of objectives in your game
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI objectivesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI victoryText;

    public TextMeshProUGUI weaponText;
    public TextMeshProUGUI altFireText;

    private int completedObjectives = 0;
    [SerializeField] private int _countdown;
    [SerializeField] private int nextLevelSceneId = 11;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("RSGameManager.Awake():: >multiple gamemagers detected");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        UpdateUI();
        gameOverText.gameObject.SetActive(false);
        victoryText.gameObject.SetActive(false);
    }

    public void AddScore(int points)
    {
        RSScoreManager.Instance.AddScore(points);
        UpdateUI();
    }

    public void ObjectiveCompleted()
    {
        completedObjectives++;
        if (completedObjectives >= totalObjectives && !victoryText.IsDestroyed())
        {
            victoryText.gameObject.SetActive(true);
            StartCoroutine(WaitForNextRound(nextLevelSceneId));

        }
        UpdateUI();
    }
    public void UpdateWeapon(RSWeaponType weaponType)
    {
        if (weaponText != null)
        {
            switch (weaponType)
            {
                case RSWeaponType.BigBullet:
                    weaponText.text = BIG_BULLET_TEXT;
                    break;
                case RSWeaponType.Bullet:
                case RSWeaponType.None:
                default:
                    weaponText.text = weaponType.ToString();
                    break;
            }
        }
    }

    public void UpdateAltWeapon(RSAlternateFireTypes altFireType)
    {
        if (weaponText != null)
        {
            weaponText.text = altFireType.ToString();
        }
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
        return RSScoreManager.Instance.score.ToString("D8");
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        StartCoroutine(WaitForNextRound(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator WaitForNextRound(int sceneId)
    {
        for (int i = 0; i < _countdown; i++)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log(".");
        }
        SceneManager.LoadScene(sceneId);
    }
}
