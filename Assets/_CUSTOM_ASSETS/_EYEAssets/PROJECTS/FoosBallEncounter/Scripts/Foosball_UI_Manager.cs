using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace EYE_Assets 
{
    public class Foosball_UI_Manager : MonoBehaviour
    {
        public delegate void ResetBallPosition();
        public static event ResetBallPosition resetBall;


        [SerializeField] TMP_Text _playerMessage;
        [SerializeField] TMP_Text _score_01;
        [SerializeField] TMP_Text _score_02;

        public void UpdatePlayerMessage(string message)
        {
            _playerMessage.text = message;
        }

        public void UpdateScore_Team_BLUE(int scoreBlue)
        {
            _score_01.text = $"TEAM BLUE\n {scoreBlue}";
            resetBall();
        }

        public void UpdateScore_Team_RED(int scoreRed)
        {
            _score_01.text = $"TEAM RED\n {scoreRed}";
            resetBall();
        }

    }
}
