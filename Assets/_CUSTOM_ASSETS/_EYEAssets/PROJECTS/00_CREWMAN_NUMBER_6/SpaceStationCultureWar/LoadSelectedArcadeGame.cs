using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EYE_Assets
{
    public class LoadSelectedArcadeGame : MonoBehaviour
    {
        [SerializeField] UI_HUDManager _uiManager;
        [SerializeField] string[] _option;
        //[SerializeField] int[] _optionValues;
        [SerializeField] int _optionID;
        //[SerializeField] int _sceneToLoad = 5;
        //[SerializeField] string _gameSceneName;

        private void Start()
        {
            _uiManager = FindObjectOfType<UI_HUDManager>();

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                int stringID = 0;
                var message = "Press: \n";
                foreach (string option in _option)
                {
                    message += stringID + 1.ToString() + " " + _option[stringID];

                    stringID++;
                }
                Debug.Log($"Press 1: {_option[0]}\n 2: {_option[1]}");
                //_uiManager.UpdatePlayerMessage(message);
                _uiManager.PlayerMessagePersist(message);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player")
            {
                string message = "";

                if (Input.anyKey)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        message = "Intergalactic Foosball";
                        _optionID = 3;
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha2))
                    {
                        message = "Zub Hunt: Cityside";
                        _optionID = 4;
                    }

                    _uiManager.UpdatePlayerMessage(message);

                    if (_optionID != 0)
                        SceneManager.LoadScene(_optionID);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
                _uiManager.PlayerMessagePersist("");
        }
    }
}