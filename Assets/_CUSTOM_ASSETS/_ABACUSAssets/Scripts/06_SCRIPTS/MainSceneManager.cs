using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        var scenes = SceneManager.sceneCount;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < scenes; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.buildIndex == 2)
                {
                    SceneManager.UnloadSceneAsync(2);
                    SceneManager.LoadScene(3, LoadSceneMode.Additive);
                }

                if (scene.buildIndex == 3)
                {
                    SceneManager.UnloadSceneAsync(3);
                    SceneManager.LoadScene(2, LoadSceneMode.Additive);
                }

            }

        }
    }
}
