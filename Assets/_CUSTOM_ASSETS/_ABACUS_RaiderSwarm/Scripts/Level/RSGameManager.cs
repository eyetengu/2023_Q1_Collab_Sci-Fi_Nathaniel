using RaiderSwarm.Enums;
using RaiderSwarm.Level;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace RaiderSwarm.Manager
{

    public class RSGameManager : MonoBehaviour
    {
        private const string BIG_LAZER_TEXT = "Big Lazer";
        public static RSGameManager Instance;
        public int totalObjectives = 1; // Set this to the total number of objectives in your game
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI objectivesText;
        public TextMeshProUGUI gameOverText;
        public TextMeshProUGUI victoryText;

        public TextMeshProUGUI weaponText;
        public TextMeshProUGUI altFireText;
        public bool GameStarted = false;
        private bool isGameOver;
        private int completedObjectives = 0;
        [SerializeField] private int _countdown;
        [SerializeField] private int nextLevelSceneId = 1;

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
        private void OnEnable()
        {
            if (RSGameInput.Instance != null)
            {
                RSGameInput.Instance.OnRestartPressed += Instance_OnRestartPressed; ;
            }
        }

        private void Instance_OnRestartPressed()
        {
            if (isGameOver)
            {
                StartCoroutine(WaitForNextRound(SceneManager.GetActiveScene().buildIndex, 0));
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
                GameStarted = false;
                StartCoroutine(WaitForNextRound(nextLevelSceneId, _countdown));

            }
            UpdateUI();
        }
        public void UpdateWeapon(RSWeaponType weaponType)
        {
            if (weaponText == null) return;

            weaponText.text = weaponType switch
            {
                RSWeaponType.BIGLAZER => BIG_LAZER_TEXT,
                _ => weaponType.ToString()
            };
            weaponText.color = weaponType switch { 
                RSWeaponType.BIGLAZER => Color.red, 
                _ => Color.white 
            };
        }

        public void UpdateAltWeapon(RSAlternateFireTypes altFireType)
        {
            if (altFireText != null)
            {
                altFireText.text = altFireType.ToString().ToUpper();
            }
            altFireText.color = altFireType switch
            {
                RSAlternateFireTypes.MISSILE => Color.red,
                _ => Color.white
            };

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
            if (GameStarted)
            {
                gameOverText.gameObject.SetActive(true);
                GameStarted = false;
                isGameOver = true;
            }
        }

        IEnumerator WaitForNextRound(int sceneId, int countdown)
        {
            for (int i = 0; i < countdown; i++)
            {
                yield return new WaitForSeconds(1f);
                Debug.Log(".");
            }
            SceneManager.LoadScene(sceneId);
        }
    }
}
