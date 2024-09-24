using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    int Experience  { get; set; }
    int Gold        { get; set; }  
    int Score       { get; set; }


    void IncreaseExperience( int experienceIn);
    void IncreaseGold(int goldIn);
    void IncreaseScore(int scoreIn);
}