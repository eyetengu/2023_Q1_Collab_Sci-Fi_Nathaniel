using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EYE_Assets
{
    public class Foosball_Goal : MonoBehaviour
    {
        [SerializeField] Foosball_UI_Manager _uiManager;
        [SerializeField] int _goal;

        [SerializeField] int _score_01;
        [SerializeField] int _score_02;


        private void OnTriggerEnter(Collider other)
        {

            if(other.tag == "Ball")
            {
                if (_goal == 1)
                {
                    _score_01++;
                    _uiManager.UpdateScore_Team_RED(_score_01);
                    Debug.Log("Team 01: " + _score_01);
                }
                else if (_goal == 2)
                { 
                    _score_02++;
                    _uiManager.UpdateScore_Team_BLUE(_score_02);
                    Debug.Log("Team 02: " + _score_02);
                }
            }
        }
    }
}
