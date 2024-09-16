using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player_Collection : MonoBehaviour, ICollectable
{
    public int experience;
    public int gold;
    public int score;


    public int Experience { get; set; }
    public int Gold { get; set; }
    public int Score { get; set; }


    public void IncreaseExperience(int experienceIn)
    {
        experience += experienceIn;
    }

    public void IncreaseGold(int goldIn)
    {
        gold += goldIn;
    }

    public void IncreaseScore(int scoreIn)
    {
        score += scoreIn;
    }

}
