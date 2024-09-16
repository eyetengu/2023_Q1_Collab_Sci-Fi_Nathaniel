using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneOfChoice : MonoBehaviour
{
    [SerializeField] UI_HUDManager _uiManager;

    [SerializeField] string[] _optionName;
    [SerializeField] int _sceneToLoad = 5;
    [SerializeField] string _gameSceneName;

    private void Start()
    {
         _uiManager = FindObjectOfType<UI_HUDManager>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var message = $"Press\n 1 {_optionName[0]}\n 2 {_optionName[1]}\n 3 {_optionName[2]}";
            Debug.Log($"Press 1 To Enter Convoy Defender\n 2 for Space Jaunt Alpha\n 3 for SideScroll Space Shooter");
            _uiManager.PlayerMessagePersist(message);
        }        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            string message = "";
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                message = "Loading: Convoy Defender";
                SceneManager.LoadScene(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneManager.LoadScene(5);
                message = "Loading: SpaceJauntAlpha";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SceneManager.LoadScene(7);
                message = "Loading: 2.5D SideScrolling Space";
            }

            if(Input.anyKey)
                _uiManager.UpdatePlayerMessage(message);
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")                    
                _uiManager.PlayerMessagePersist("");        
    }
}
