using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Radar : MonoBehaviour
{
    //This class is designed to be a character add-on that can be used 
    //on the enemies and npcs. A variation may be used by the player.
    //It uses a sphere collider to detect potential targets as they enter the zone and
    //removes them when they leave the zone
    //Custom functions include: Select Closest/Furthest/Random Target, set any but player as target & Set Player As Target

    [Header("CURRENT TARGET")]
    [SerializeField] Transform _currentTarget;

    [Header("Detectable Bodies")]
    [SerializeField] Transform _playerTransform;

    [SerializeField] List<Transform> _enemyAgents;
    [SerializeField] List<Transform> _availableTargets = new List<Transform>();

    [Header("TARGET ACQUISITION")]
    [SerializeField] bool _selectClosestTarget;
    [SerializeField] bool _selectRandomTarget;
    [SerializeField] bool _selectPlayerAsTarget;
    [SerializeField] bool _selectAnyExceptPlayer = true;
    [SerializeField] bool _selectFurthestTarget;
    
    float _distance;


    void Update()
    {
        //Debug.Log("Enemies: " + _enemyAgents.Count);

        if(_currentTarget == null)
        {            
            SelectTarget();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Other: " + other.name);
        if(other.tag == "Player")   { _playerTransform = other.transform;  SelectTarget(); }
        if(other.tag == "Enemy")    { _enemyAgents.Add(other.transform);    }
        
        //The scanning of planets will be used primarily for away team missions so it may be left for later.
        //if(other.tag == "Planet")   {_planetTransforms.Add(other.transform);   }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (_playerTransform == null)
                _playerTransform = other.transform;
        }
        if(other.tag == "Enemy")
        { 
            if (!_enemyAgents.Contains(other.transform))
                _enemyAgents.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")  { _playerTransform = null;                      }
        if(other.tag == "Enemy")    { _enemyAgents.Remove(other.transform);         }

        //if(other.tag == "Planet")   { _planetTransforms.Remove(other.transform);    }
    }

    void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))        
            SelectTarget();        
    }

    void MaintainListOfTargets()
    {
        _availableTargets.Clear();
        if (!_selectAnyExceptPlayer)
        {
            if (_playerTransform != null)
                _availableTargets.Add(_playerTransform);
        }

        if (_enemyAgents != null)
        {
            foreach (Transform agent in _enemyAgents)
                _availableTargets.Add(agent);
        }
    }

    void SelectTarget()
    {
        MaintainListOfTargets();

    //Select Targets from newly created list or directly
        //SELECT CLOSEST TARGET
        if      (_selectClosestTarget   &&  _availableTargets.Count     >       0)
        {
            float closestTarget = 300.0f;

            foreach (Transform target in _availableTargets)
            {
                _distance = Vector3.Distance(transform.position, target.position);
                if (_distance < closestTarget)
                {
                    closestTarget = _distance;
                    _currentTarget = target;
                }
            }
        }

        //SELECT FURTHEST TARGET
        else if (_selectFurthestTarget  &&  _availableTargets.Count     >       0)
        {
            float furthestDistance = 0;
            foreach(var target in _availableTargets)
            {
                _distance = Vector3.Distance(transform.position, target.position);
                if(_distance > furthestDistance)
                {
                    furthestDistance = _distance;
                    _currentTarget = target;
                }
            }
        }

        //SELECT RANDOM TARGET
        else if (_selectRandomTarget    &&  _availableTargets.Count     >       0)
        {
            var randomTarget = Random.Range(0, _availableTargets.Count - 1);
            _currentTarget = _availableTargets[randomTarget];
        }

        //SELECT PLAYER AS TARGET
        else if (_selectPlayerAsTarget  &&  _playerTransform           !=      null)
            _currentTarget = _playerTransform;
    }    

//Accessible Methods
    public Transform ReturnTargetTransform()
    {
        SelectTarget();
        return _currentTarget;
    }
}


///The Enemy Radar is a component that will 'reach out' and gather data on appropriate search criteria(planet, enemy, player, npc, asteroid,space phenomena)
///It may have a ui configuration all its own to fully interact with its potential.
///Assuming you had a selector to set one target type over another(priority) you could (ScanForType() switch(type))
///if you set the player as a high priority- will it become the new _currentTarget? 
///breaking your pursuit of the current target?
///