using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    public  static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("Instance = Null");
            return _instance;
        }
    }

    public int PlayerScore { get; set; }


    private void Awake()
    {
        _instance = this;
    }

    public void SetScore(int incomingScore)
    {
        PlayerScore += incomingScore;
    }

    public void ResetScore()
    {
        PlayerScore = 00000000;
    }
}
