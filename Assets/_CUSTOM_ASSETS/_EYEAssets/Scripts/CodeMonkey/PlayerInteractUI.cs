using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject _containerGameObject;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TMP_Text _interactionText;


    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null)        
            Show(playerInteract.GetInteractableObject());        
        else
            Hide();
    }

    void Show(NPCInteract npcInteractable)
    {
        _containerGameObject.SetActive(true);
        _interactionText.text = npcInteractable.GetInteractText();
    }

    void Hide()
    { _containerGameObject.SetActive(false); }






}
