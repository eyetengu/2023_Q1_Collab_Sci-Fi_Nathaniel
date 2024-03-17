using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarshipScheduler : MonoBehaviour
{
    public delegate void ChangeTimeOfDay();
    public ChangeTimeOfDay timeOfDay;
    private bool _isDay;

    [SerializeField] private GameObject[] _lights;

    void OnEnable()
    {
        timeOfDay += UpdateTimeOfDay;
    }

    private void Start()
    {
        if (timeOfDay != null)
        {
            //timeOfDay();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isDay = !_isDay;
            timeOfDay();
        }
        //StartCoroutine(TimeChangeTimer());
    }

    void UpdateTimeOfDay()
    {
        Debug.Log("Updating at source");
        if (_isDay)
        {
            foreach (var light in _lights)
            {
                light.SetActive(false);
            }
        }
        else
        {
            foreach (var light in _lights)
            {
                light.SetActive(true);
            }
        }
    }

    IEnumerator TimeChangeTimer()
    {
        yield return new WaitForSeconds(3);
        UpdateTimeOfDay();
    }

    private void OnDisable()
    {
        timeOfDay -= UpdateTimeOfDay;
    }

}
