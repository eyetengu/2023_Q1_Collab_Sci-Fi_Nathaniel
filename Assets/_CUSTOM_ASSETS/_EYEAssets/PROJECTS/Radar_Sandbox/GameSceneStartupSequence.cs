using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameSceneStartupSequence : MonoBehaviour
{
//CONVOY
    [SerializeField] Transform _largeCarrier;
    [SerializeField] float _carrierSpeed;
    float _carrierStep;

//PIRATES
    [SerializeField] Transform[] _pirateVessels;
    [SerializeField] float _pirateSpeed = 125f;
    [SerializeField] Transform[] _piratePoints;
    [SerializeField] float _retreatSpeed = 50;
    
//WARP GATE
    [SerializeField] Transform _warpGate;

    bool _convoyHasArrived;
    bool _releasingPirates;
    int _pirateID;
    bool _piratesAssembled;
    bool _retreat;
    float _retreatStep;


//BUILT-IN FUNCTIONS
    void Start()
    {
        CueConvoy();
    }

    void Update()
    {
    //run our speed variable setup
        _carrierStep = _carrierSpeed * Time.deltaTime;
        _retreatStep = _retreatSpeed * Time.deltaTime;


        if (_convoyHasArrived == false)
            StartCoroutine(MoveConvoyToScreen());
        else if (_convoyHasArrived && _piratesAssembled == false)
        {
            if (_releasingPirates)
                MovePiratesIntoPosition();
            else if (_releasingPirates == false)
                CuePirates();
        }
        //else
            //Debug.Log("READY TO PLAY");

        if (Input.GetKeyDown(KeyCode.L))
            _retreat = !_retreat;

        if (_retreat)
        {
            RetreatPirates();
            MoveWarpGate();
        }
    }



//CONVOY FUNCTIONS
    void CueConvoy()
    {
        _largeCarrier.gameObject.SetActive(true);
    }

    IEnumerator MoveConvoyToScreen()
    {
        yield return new WaitForSeconds(2.0f);
            _convoyHasArrived = true;
    }


//PIRATE FUNCTIONS
    void CuePirates()
    {
        _releasingPirates = true;
        //Debug.Log("Cuing Pirates");

        ReleaseNextPirate();
    }

    void ReleaseNextPirate()
    {
        //Debug.Log("Releasing PirateID: " + _pirateID);
        if (_pirateID <= _pirateVessels.Length - 1)
        {
            _pirateVessels[_pirateID].gameObject.SetActive(true);
        }
    }

    void MovePiratesIntoPosition()
    {
        //Debug.Log("Moving Pirates Into Position");
        if (_pirateID <= _pirateVessels.Length - 1)
        {
            if (_pirateVessels[_pirateID].position != _piratePoints[_pirateID].position)
                _pirateVessels[_pirateID].position = Vector3.MoveTowards(_pirateVessels[_pirateID].position, _piratePoints[_pirateID].position, _pirateSpeed * Time.deltaTime);
            else
                ChooseNextPirateToSend();
        }
    }

    void ChooseNextPirateToSend()
    {
        //Debug.Log("Choosing Next Pirate");
        _pirateID++;

        if (_pirateID <= _pirateVessels.Length - 1)
            ReleaseNextPirate();
        else if(_pirateID >= _pirateVessels.Length)
        {
            _releasingPirates = false;
            _piratesAssembled = true;


            return;
        }
    }        

    void RetreatPirates()
    {
        foreach (var unit in _pirateVessels)
            unit.transform.position += new Vector3(0, 0, 125 * Time.deltaTime);
    }


//WARP GATE
    void MoveWarpGate()
    {
        _warpGate.position += new Vector3(0, 0, -30 * Time.deltaTime);
    }
}
