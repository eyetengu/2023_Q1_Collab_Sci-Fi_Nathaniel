using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private DifficultyLevel _difficultyLevel;
    [SerializeField] private MissionType _missionType;
    [SerializeField] private float _remainingMissionTime = -1;
    [SerializeField] private bool _levelCompleted;
    private bool _stopTimerCalled;

    public MissionType MissionType { get { return _missionType; } }
    public DifficultyLevel DifficultyLevel { get { return _difficultyLevel; } }
    public float RemainingMissionTime { get { return _remainingMissionTime; } }

    public void SetMission(MissionType missionType)
    {
        _missionType = missionType;
    }
    public void SetDifficulty(DifficultyLevel level)
    {
        _difficultyLevel = level;
    }
    public void SetLevelCompleted()
    {
        _levelCompleted = true;
    }
    public void StartMissionTimer()
    {
        switch (_difficultyLevel)
        {
            case DifficultyLevel.Easy:
                _remainingMissionTime = Time.time + 600.0f;
                StartCoroutine(CountDownTimer());
                break;
            case DifficultyLevel.Medium:
                _remainingMissionTime = Time.time + 300.0f;
                StartCoroutine(CountDownTimer());
                break;
            case DifficultyLevel.Hard:
                _remainingMissionTime = Time.time + 300.0f;
                StartCoroutine(CountDownTimer());
                break;
            case DifficultyLevel.Free:
                StartCoroutine(CountUpTimer());
                break;
            default:
                Debug.Log("Difficulty not valid");
                break;
        }
    }
    public void StopMissionTimer()
    {
        _stopTimerCalled = true;
    }
    IEnumerator CountDownTimer()
    {
        while (!_levelCompleted || !_stopTimerCalled)
        {
            _remainingMissionTime -= 1;
            if (_remainingMissionTime < 0)
            {
                SetLevelCompleted();
            }
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator CountUpTimer()
    {
        while (!_levelCompleted || !_stopTimerCalled)
        {
            _remainingMissionTime += 1;
            yield return new WaitForSeconds(1);
        }
    }

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