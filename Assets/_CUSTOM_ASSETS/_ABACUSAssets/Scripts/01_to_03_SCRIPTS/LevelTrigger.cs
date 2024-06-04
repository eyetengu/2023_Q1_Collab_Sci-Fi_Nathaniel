using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private DifficultyLevel difficultyLevel;
    [SerializeField] private MissionType missionType;

    private void Start()
    {
        StartCoroutine(BeginLevel());
    }

    IEnumerator BeginLevel()
    {
        levelManager.SetDifficulty(difficultyLevel);
        levelManager.SetMission(missionType);
        levelManager.StartMissionTimer();
        yield return null;
    }
}
