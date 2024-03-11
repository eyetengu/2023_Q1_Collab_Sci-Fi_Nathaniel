using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweepo_Behavior : MonoBehaviour
{
    [SerializeField] List<Transform> _brushes;
    [SerializeField] List<Transform> _wheels;
    [SerializeField] float _brushSpeed = 500f;
    [SerializeField] float _wheelSpeed = 25f;
    [SerializeField] GameObject _strobe;

    private void Start()
    {
        _strobe.SetActive(false);

        StartCoroutine(StrobeTimer());
    }
    void Update()
    {
        foreach(var brush in _brushes) 
        {
            brush.Rotate(0, _brushSpeed * Time.deltaTime, 0);
        }
        foreach(var wheel in _wheels) 
        {
            wheel.Rotate(_wheelSpeed * Time.deltaTime,0,0);
        }
    }

    void Work_Strobe()
    {
        StartCoroutine(StrobeTimer());

    }

    IEnumerator StrobeTimer()
    {
        yield return new WaitForSeconds(1);
        _strobe.SetActive(true);
        yield return new WaitForSeconds(.1f);
        _strobe.SetActive(false);
        Work_Strobe();
    }
}
