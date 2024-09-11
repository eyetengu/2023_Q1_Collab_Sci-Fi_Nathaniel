using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReturnToMainMenu : MonoBehaviour
{
    bool _isSwitchingScenes;
    [SerializeField] int _countdownReturn = 2;



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
    public void ReturnToOriginalMenu()
    {        
        _isSwitchingScenes = true;
        Debug.Log("Returning To Main Menu");

        StartCoroutine(SceneLoadTimer());        
    }


//COROUTINES
    IEnumerator SceneLoadTimer()
    {
        for (int i = 0; i < _countdownReturn; i++)
        {
            yield return new WaitForSeconds(.3f);
            Debug.Log(".");
        }
        SceneManager.LoadScene(0);
    }
}
