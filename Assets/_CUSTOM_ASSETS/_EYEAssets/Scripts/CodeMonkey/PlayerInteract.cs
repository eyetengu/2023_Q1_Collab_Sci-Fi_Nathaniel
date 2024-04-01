using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2.0f;

            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteract npcInteractable))
                {
                    // npcInteractable.Interact(transform);
                }
            }
        }
    }

    public NPCInteract GetInteractableObject()
    {
        List<NPCInteract> npcInteractableList = new List<NPCInteract>();
        float interactRange = 4f;
        
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        
        foreach(Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NPCInteract npcInteractable))
                npcInteractableList.Add(npcInteractable);
        }

        NPCInteract closestNPCInteractable = null;
        foreach(NPCInteract npcInteractable in npcInteractableList)
        {
            if(closestNPCInteractable == null)
            {
                closestNPCInteractable = npcInteractable;
            }
            else
            {
                if(Vector3.Distance(transform.position, npcInteractable.transform.position) < Vector3.Distance(transform.position, closestNPCInteractable.transform.position))
                {
                    closestNPCInteractable = npcInteractable;
                }
            }
        }
        return closestNPCInteractable;
    }
}
