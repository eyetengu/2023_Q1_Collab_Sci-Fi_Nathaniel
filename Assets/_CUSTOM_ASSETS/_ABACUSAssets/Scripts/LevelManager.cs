using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public MissionType MissionType;
    public DifficultyLevel difficultyLevel;

}

public enum MissionType
{
    Gathering,
    ProtectDrones,
    EndEscape
}

public enum DifficultyLevel
{
    Easy,
    Medium,
    Hard,
    Free
}