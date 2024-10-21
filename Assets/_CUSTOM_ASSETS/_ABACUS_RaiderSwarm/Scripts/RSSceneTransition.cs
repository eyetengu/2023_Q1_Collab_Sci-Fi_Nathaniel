using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RSSceneTransition : MonoBehaviour
{
    public void OnAnimationComplete()
    {
        SceneManager.LoadScene((int)SceneSelection.MainMenu); // Replace with your scene name

    }
}
