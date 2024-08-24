using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CentralCore_Scene_Manager : MonoBehaviour
{
    //SCENE INDEX
    //00- CentralCore Main Menu
    //01- Convoy Defender
    //02- Resource Collector
    //03- Intergalactic Foosball
    //04- Asteroid Dodge
    //05- Space Jaunt Alpha
    //06- Starship Walkthrough
    //07- 2.5D Space SideScroller


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void LoadSelectedScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
