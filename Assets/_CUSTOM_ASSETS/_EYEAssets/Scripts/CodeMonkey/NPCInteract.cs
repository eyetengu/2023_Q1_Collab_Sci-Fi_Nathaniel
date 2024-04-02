using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    [SerializeField] private string interactText;

    private Animator _animator;
    private NPCHeadLookAt npcHeadLookAt;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        npcHeadLookAt = GetComponent<NPCHeadLookAt>();
    }

    public void Interact(Transform interactorTransform)
    {
        //ChatBubble3D.Create(transform.transform, new V3(-.3f, 1.7f, 0f), ChatBubble3D.IconType.Happy, "Hello There!");
        //_animator.SetTrigger("Talk");

        float playerHeight = 1.7f;
        npcHeadLookAt.LookAtPosition(interactorTransform.position + Vector3.up * playerHeight);
        Debug.Log("Interacting");
    }

    public string GetInteractText()
    {
        return interactText;
    }
}
