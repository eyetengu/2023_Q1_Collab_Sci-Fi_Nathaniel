using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneOfChoice : MonoBehaviour
{
    [SerializeField] int _sceneToLoad = 5;
    [SerializeField] string _gameSceneName;
    


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            var message = $"Press E To Enter {_gameSceneName} ";
            Debug.Log($"Press E To Enter {_gameSceneName}");// _uiManager.UpdatePlayerMessage(message);
        }
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
            SceneManager.LoadScene(_sceneToLoad);
    }


}
