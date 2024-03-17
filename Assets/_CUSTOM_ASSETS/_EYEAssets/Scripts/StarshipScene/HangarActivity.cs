using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangarActivity : MonoBehaviour
{
    [SerializeField] private Transform[] _hangarDoors;
    
    [SerializeField] bool _hangarDoorsOpening;
    [SerializeField] float _hangarDoorOpenRate = 2.0f;

    float _step;
    [SerializeField] float _speed = 2.0f;



    void Update()
    {
        _step = _speed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(HangarDoorOpenRate());
            _hangarDoorsOpening = true;
            _speed = 1;
        }
        
        if(_hangarDoorsOpening)
            OpenHangarDoors();            
    }

    void OpenHangarDoors()
    {        
        _hangarDoors[0].Translate(_step, 0, 0);
        _hangarDoors[1].Translate(-_step, 0, 0);
    }


    IEnumerator HangarDoorOpenRate()
    {
        yield return new WaitForSeconds(_hangarDoorOpenRate);
        
        _speed = -1;
        
        yield return new WaitForSeconds(_hangarDoorOpenRate);
        
        _speed = 0;
        _hangarDoorsOpening = false;
    }
}
