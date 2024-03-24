using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollectorBehavior : MonoBehaviour
{
    [SerializeField]
    Transform[] _destinations;
    [SerializeField] Transform _base;
    Transform _currentTarget;

    [SerializeField] private float _speed = 4;
    float _speedMultiplier = 1.0f;
    float _step;

    float _deliveryDelay = 5;
    float _gatherDelay = 5;

    int _gas;
    int _crystals;
    int _ore;
    int _cargo;

    [SerializeField] ResourceCollectionUI _uiScript;


    private void Start()
    {
        //_uiScript = GameObject.FindObjectOfType<ResourceCollectionUI>();

        _currentTarget = _destinations[0];
    }

    private void Update()
    {
        _step = _speed * _speedMultiplier * Time.deltaTime;

        MoveToTarget();
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _step);
        TurnToFaceTarget();
    }    

    void TurnToFaceTarget()
    {
        var targetDirection = _currentTarget.position - transform.position;
        var newDirection = Vector3.RotateTowards(transform.forward, targetDirection, _step / 2, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Base")
            StartCoroutine(ResourceDeliveryTimer());
        else
            StartCoroutine(ResourceGatherTimer(other.tag));
    }

    void ChooseRandomDestination()
    {
        _currentTarget = _destinations[Random.Range(0, _destinations.Length-1)];
    }

    IEnumerator ResourceDeliveryTimer()
    {
        yield return new WaitForSeconds(_deliveryDelay);
        _cargo = 0;
        _uiScript.UpdateCargoCount(_cargo);
        ChooseRandomDestination();
    }

    IEnumerator ResourceGatherTimer(string resource)
    {
        yield return new WaitForSeconds(_gatherDelay);
        switch(resource)
        {
            case "Gas":
                _gas+= 5;
                _uiScript.UpdateGasQuantity(_gas);
                    break;
            case "Crystal":
                _crystals+=5;
                _uiScript.UpdateCrystalQuantity(_crystals);
                    break;
            case "Ore":
                _ore += 5;
                _uiScript.UpdateOreQuantity(_ore);
                    break;

            default:
                    break;
        }
        _cargo += 5;
        _uiScript.UpdateCargoCount(_cargo);
        _currentTarget = _base;
    }

}
