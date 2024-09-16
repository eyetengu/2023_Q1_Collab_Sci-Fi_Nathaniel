using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene_Manager : MonoBehaviour
{
    bool _gameOver;




    private void OnEnable()
    {
        Event_Manager.gameOver += Event_Manager_gameOver;
        Event_Manager.win += Event_Manager_win;
        Event_Manager.lose += Event_Manager_lose;
    }

    private void OnDisable()
    {
        Event_Manager.gameOver += Event_Manager_gameOver;
        Event_Manager.win += Event_Manager_win;
        Event_Manager.lose += Event_Manager_lose;
    }

    private void Event_Manager_gameOver()
    {
        _gameOver = true;
    }

    private void Event_Manager_win()
    {
        _gameOver = true;
    }

    private void Event_Manager_lose()
    {
        _gameOver = true;
    }

    private void Update()
    {
        if(_gameOver && Input.GetKeyDown(KeyCode.R))
        {
            LoadSelectedScene(0);
        }
    }

    public void LoadSelectedScene(int sceneIndex)
    {
        _gameOver = false;
        SceneManager.LoadScene(sceneIndex);
    }
}
