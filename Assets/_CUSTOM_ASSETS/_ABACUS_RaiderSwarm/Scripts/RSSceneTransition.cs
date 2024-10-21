using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RSSceneTransition : MonoBehaviour
{
    private int default_scene = 0;
    public void OnAnimationComplete()
    {
        SceneManager.LoadScene(default_scene); // Replace with your scene name

    }
}
