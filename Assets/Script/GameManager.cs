using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public static int playerLives = 3;
    public static int currentScene = 0;
    public static int gameLevelScene = 3;
    bool died = false;
    public bool Died
    {
        get { return died; }
        set { died = value; }
    }

    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        CheckGameManagerIsInTheScene();
        currentScene = UnityEngine.SceneManagement.SceneManager.
        GetActiveScene().buildIndex;
        LightAndCameraSetup(currentScene);
    }

    void LightAndCameraSetup(int sceneNumber)
    {
        switch (sceneNumber)
        {
            //testLevel, Level1, Level2, Level3
            case 3:
            case 4:
            case 5:
                {
                    LightSetup();
                    CameraSetup();
                    break;
                }
        }
    }

    void CheckGameManagerIsInTheScene()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void CameraSetup()
    {
        GameObject gameCamera = GameObject.FindGameObjectWithTag("MainCamera");

        //Camera Transform
        gameCamera.transform.position = new Vector3(0, 0, -300);
        gameCamera.transform.eulerAngles = new Vector3(0,0,0);

        //Camera Properties
        gameCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        gameCamera.GetComponent<Camera>().backgroundColor = new Color32(0,0,0,255);
    }

    void LightSetup()
    {
        GameObject dirLight = GameObject.Find("Directional Light");
        dirLight.transform.eulerAngles = new Vector3(50,-30,0);
        dirLight.GetComponent<Light>().color = new Color32(152,204,255,255);
    }
    public void LifeLost()
    {
        //lose life
        if (playerLives >= 1)
        {
            playerLives--;
            Debug.Log("Lives left: " + playerLives);
            GetComponent<ScenesManager>().ResetScene();
        }
        else
        {
            playerLives = 3;
            GetComponent<ScenesManager>().GameOver();
        }
    }
}
