using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RaiderSwarm.Level
{

    public class RSScoreManager : MonoBehaviour
    {
        public static RSScoreManager Instance;
        public int score = 0;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void AddScore(int points)
        {
            score += points;
        }
    }
}
