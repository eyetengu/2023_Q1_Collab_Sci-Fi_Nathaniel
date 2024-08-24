using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction_Interface : MonoBehaviour, IInteractable
{
    [SerializeField] private float _detectionRadius = 5.0f;



    public void Interact(GameObject interactor)
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void DetectInteractable()
    {
        Collider[] result = Physics.OverlapSphere(transform.position, _detectionRadius);
    }

    void Ontriggerenter(Collider other)
    {
        DetectInteractable();
    }
}
