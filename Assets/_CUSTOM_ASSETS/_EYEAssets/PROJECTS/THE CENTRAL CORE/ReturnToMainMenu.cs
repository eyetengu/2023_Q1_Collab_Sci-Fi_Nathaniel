using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReturnToMainMenu : MonoBehaviour
{
    bool _isSwitchingScenes;


//BUILT-IN FUNCTIONS
    void Start()
    {
        
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


//COROUTINES
    IEnumerator SceneLoadTimer()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(.3f);
            Debug.Log(".");
        }
        SceneManager.LoadScene(0);
    }
}
