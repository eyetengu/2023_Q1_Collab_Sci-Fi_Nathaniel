using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReturnToMainMenu : MonoBehaviour
{
    bool _isSwitchingScenes;
    [SerializeField] int _countdownReturn = 2;
    [SerializeField] bool _returnToBase;


//BUILT-IN FUNCTIONS
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isSwitchingScenes == false)
            ReturnToOriginalMenu();
    }


//CORE FUNCTIONS
    void ReturnToOriginalMenu()
    {        
        _isSwitchingScenes = true;
        Debug.Log("Returning To Main Menu");

        StartCoroutine(SceneLoadTimer());        
    }

    public void GoToSelectedScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

//COROUTINES
    IEnumerator SceneLoadTimer()
    {
        for (int i = 0; i < _countdownReturn; i++)
        {
            yield return new WaitForSeconds(.3f);
            Debug.Log(".");
        }

        if (_returnToBase)
            SceneManager.LoadScene(0);
        else if(_returnToBase == false)
            SceneManager.LoadScene(0);

    }
}
